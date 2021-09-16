using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using OA_DAL.Models;
using OA_Service.AppServices;
using OA_Service.ViewModels;

namespace OA_Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly AccountAppService _accountAppService;
        private readonly RoleAppService _roleAppService;
        
        

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            AccountAppService accountAppService,
            RoleAppService roleAppService,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _accountAppService = accountAppService;
            _roleAppService = roleAppService;
            _roleManager = roleManager;
        }

        [BindProperty]
        public RegisterViewModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        //public class InputModel
        //{
        //    [Required]
        //    [EmailAddress]
        //    [Display(Name = "Email")]
        //    public string Email { get; set; }

        //    [Required]
        //    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        //    [DataType(DataType.Password)]
        //    [Display(Name = "Password")]
        //    public string Password { get; set; }

        //    [DataType(DataType.Password)]
        //    [Display(Name = "Confirm password")]
        //    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        //    public string ConfirmPassword { get; set; }

        //    [Required]
        //    [StringLength(14)]
        //    [MaxLength(14)]
        //    [MinLength(14)]
        //    public string SSN { get; set; }
        //}

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {

                var us = _userManager.Users.Where(u => u.SSN == Input.SSN).ToList();

                if(us != null && us.Any(u => _userManager.IsInRoleAsync(u, Input.Account_Type.ToString()).Result))
                {
                    ModelState.AddModelError("SSN", "National Id Number already Exists");
                    return Page();
                }

                ImageUploaderService profileImage = null;
                ImageUploaderService ssnImage = null;
                ImageUploaderService licenceImage = null;

                profileImage = new ImageUploaderService(Input.FormFileProfile, Directories.Users);
                Input.Photo = profileImage.GetImageName();

                ssnImage = new ImageUploaderService(Input.FormFileSSN, Directories.UserPhotos);

                licenceImage = new ImageUploaderService(Input.FormFileLicencePhoto, Directories.UserPhotos);

                Input.UserPhoto = new UserPhoto { LicencePhoto = licenceImage.GetImageName(), SSN_Photo = ssnImage.GetImageName() };

                var user = new ApplicationUser {
                    UserName = Input.Email,
                    Email = Input.Email,
                    SSN = Input.SSN,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    Address = Input.Address,
                    PhoneNumber = Input.PhoneNumber,
                    Photo = Input.Photo,
                    UserPhoto = Input.UserPhoto,
                    IsActive = false
                };

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    profileImage.SaveImageAsync();
                    licenceImage.SaveImageAsync();
                    ssnImage.SaveImageAsync();
                    
                    var userId = _accountAppService.Find(Input.Email, Input.Password).Id;

                    if (_roleAppService.GetAllRoles().Count < Enum.GetNames(typeof(Role_Name)).Length)
                    {
                        foreach (Role_Name role in (Role_Name[])Enum.GetValues(typeof(Role_Name)))
                        {
                            if (!_roleAppService.CheckIfRoleExist(role))
                            {
                                IdentityRole Role = new IdentityRole { Name = role.ToString() };
                                await _roleManager.CreateAsync(Role);
                            }
                        }
                    }

                    _accountAppService.AssignToRole(userId, Input.Account_Type);

                    if (Input.Account_Type == Role_Name.Car_Owner)
                    {
                        returnUrl = "/car/addcar";
                    }

                    _logger.LogInformation("User created a new account with password.");
                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                    //    protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    //if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    //{
                    //    return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    //}
                    //else
                    //{

                    //}
                    await _signInManager.SignInAsync(user, isPersistent: true);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}

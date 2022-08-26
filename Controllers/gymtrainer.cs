using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactProjectGym.Model;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace ReactProjectGym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class gymtrainer : ControllerBase
    {
        private readonly DataContext _context;
        private IHostingEnvironment _hostingEnvironment;
        public gymtrainer(DataContext context, IHostingEnvironment environment)
        {
            _context = context;
            _hostingEnvironment = environment ?? throw new ArgumentNullException(nameof(environment));
        }




        // Post: api/User/UpdateUserData
        [Route("/updateuserdata")]
        [HttpPost]
        public async Task<IActionResult> UpdateUserData([FromForm] UserDataModel userData)
        {
            Dictionary<string, string> resp = new Dictionary<string, string>();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                //getting user from the database
                //var userobj = await _context.userDataModels.FindAsync(userData.Id);
                //if (userobj != null)
                //{
                    //Get the complete folder path for storing the profile image inside it.  
                    var path = Path.Combine(_hostingEnvironment.WebRootPath, "images/");

                    //checking if "images" folder exist or not exist then create it
                    if ((!Directory.Exists(path)))
                    {
                        Directory.CreateDirectory(path);
                    }
                    //getting file name and combine with path and save it
                    string filename = userData.ProfileImage.FileName;
                    using (var fileStream = new FileStream(Path.Combine(path, filename), FileMode.Create))
                    {
                        await userData.ProfileImage.CopyToAsync(fileStream);
                    }
                    //save folder path 
                    //suserobj.ProfileImage = "images/" + filename;
                    _context.userDataModels.AddAsync(userData);
                    await _context.SaveChangesAsync();
                    //return api with response
                    resp.Add("status ", "success");
                //}

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(resp);
        }
    }
}

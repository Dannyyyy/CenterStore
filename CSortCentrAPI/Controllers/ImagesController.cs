using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CSortCentrAPI.Models;
using System.Web;
using System.Threading.Tasks;

namespace CSortCentrAPI.Controllers
{
    public class ImagesController : ApiController
    {
        private MessageContext db = new MessageContext();

        //POST: api/Images
        [ResponseType(typeof(Image))]
        public async Task<HttpResponseMessage> PostImage()
        {
            var infoMessages = new List<string>();
            try
            {
                var httpRequest = HttpContext.Current.Request;

                foreach (string file in httpRequest.Files)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                    var postedFile = httpRequest.Files[file];
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {

                        int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB  

                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
                        
                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();
                        if (!AllowedFileExtensions.Contains(extension))
                        {

                            var messageImageExtension = string.Format("Please Upload image of type .jpg,.gif,.png.");
                            return Request.CreateResponse(HttpStatusCode.BadRequest, messageImageExtension);
                        }
                        else if (postedFile.ContentLength > MaxContentLength)
                        {

                            var messageImageSize = string.Format("Please Upload a file upto 1 mb.");
                            return Request.CreateResponse(HttpStatusCode.BadRequest, messageImageSize);
                        }
                        else
                        {
                            Image uploadImage = new Image();
                            uploadImage.IsIdentified = false;
                            uploadImage.MessageId = 0;
                            int length = postedFile.ContentLength;
                            uploadImage.Picture = new byte[length];
                            postedFile.InputStream.Read(uploadImage.Picture, 0, length);
                            uploadImage.Name = postedFile.FileName.Split('.')[0];
                            db.Images.Add(uploadImage);
                            db.SaveChanges();
                        }
                    }

                    var message = string.Format("Image {0} Updated Successfully.", postedFile.FileName);
                    infoMessages.Add(message);
                    
                }
                if (infoMessages.Count !=0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Created, "Image(s) is upload");
                }
                    
                var messageUploadFile = string.Format("Please Upload a image.");
                return Request.CreateResponse(HttpStatusCode.NotFound, messageUploadFile);
            }
            catch (Exception ex)
            {
                var messageUnknownError = string.Format("Unknown error(exception)");
                return Request.CreateResponse(HttpStatusCode.NotFound, messageUnknownError);
            }
        }

        //Get: api/lastimage
        [Route("api/lastimage")]
        [ResponseType(typeof(Image))]
        public IHttpActionResult GetLastImage()
        {
            Image image = db.Images.ToList().FindLast(t => t.Picture != null);
            if (image == null)
            {
                return NotFound();
            }

            return Ok(image);
        }

        // GET: api/Images
        public IQueryable<Image> GetImages()
        {
            return db.Images;
        }

        // GET: api/Images/5
        [ResponseType(typeof(Image))]
        public IHttpActionResult GetImage(int id)
        {
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return NotFound();
            }

            return Ok(image);
        }

        // DELETE: api/Images/5
        [ResponseType(typeof(Image))]
        public IHttpActionResult DeleteImage(int id)
        {
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return NotFound();
            }

            db.Images.Remove(image);
            db.SaveChanges();

            return Ok(image);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ImageExists(int id)
        {
            return db.Images.Count(e => e.Id == id) > 0;
        }
    }
}
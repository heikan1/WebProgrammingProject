using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using WebProgrammingProject.Models.db;
using static System.Net.Mime.MediaTypeNames;

namespace WebProgrammingProject.Controllers
{
    public class messageContent
    {
        public string type { get; set; }
        public string text { get; set; }
        public imageUrl image_url { get; set; }
    }

    public class imageUrl
    {
        public string url { get; set; }
    }

    public class message
    {
        public string role { get; set; }
        public List<messageContent> content { get; set; }
    }

    public class request
    {
        public List<message> messages { get; set; }
        public string model { get; set; }
        public int temperature { get; set; } = 1;
        public int max_tokens { get; set; } = 128;
        public int top_p { get; set; } = 1;
        public bool stream { get; set; } = false;
        public object stop { get; set; } = null;
    }

    public class Ai : Controller
    {
        private readonly Db _context;
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "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";
        private static readonly string ApiKey = "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"; // API anahtarınızı buraya ekleyin
        private static readonly string ApiEndpoint = "https://api.groq.com/openai/v1/chat/completions"; // API endpoint adresi
        private readonly IWebHostEnvironment _environment;

        public static readonly string aimodel = "llama-3.2-90b-vision-preview";
        public static readonly string query = "Kendini profesyonel bir erkek kuaförü olarak düşün ve fotoğraftaki kişiye yeni bir saç modeli öner. Kısa bir cevap ver (4 cümleden kısa). Cevabın en azından 1 saç modeli ismi içersin. Kelime tekrarlarından kaçın.";

        public Ai(Db context, IWebHostEnvironment environment)
        {
            _context = context;
            _httpClient = new HttpClient();
            _environment = environment;
        }

        public IActionResult Index()
        {
            ViewBag.EditedImageUrl = null;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile photo)
        {
            
            //fotografi basari ile aliyorum apiye gonderip responseu handlelicam bitecek
            if (photo != null && photo.Length > 0)
            {
                //string apiKey = _apiKey; // API anahtarınız burada
                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);

                string base64Image;
                using (var memoryStream = new MemoryStream())
                {
                    await photo.CopyToAsync(memoryStream);
                    byte[] byteArray = memoryStream.ToArray();
                    base64Image = Convert.ToBase64String(byteArray);
                }

                //
                request r = new request();
                messageContent messageContent1 = new messageContent{
                    type="text",
                    text=query
                };
                imageUrl img = new imageUrl
                {
                    url = $"data:image/jpeg;base64,{base64Image}"
                };
                messageContent messageContent2 = new messageContent
                {
                    type = "image_url",
                    image_url = img
                };
                message msg1 = new message
                {
                    role="user",
                    content = new List<messageContent>
                    { messageContent1,messageContent2 }
                };
                r.model = aimodel;
                r.messages = new List<message> {msg1 };
                var settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
                // JSON Mesajı Oluşturma
                string json = JsonConvert.SerializeObject(r, settings);

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {ApiKey}");

                    //var jsonPayload = JsonConvert.SerializeObject(messagePayload);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(ApiEndpoint, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var jsonResponse = JObject.Parse(responseContent);
                        var message = jsonResponse["choices"]?[0]?["message"]?["content"]?.ToString();

                        ViewBag.EditedImageUrl = message;
                        ViewBag.imageUrl = img.url;
                        return View();
                    }
                    ViewBag.EditedImageUrl = "API isteği başarısız";
                    return View();
                }
            }
            else
            {
                ViewBag.Error = "Lütfen bir fotoğraf yükleyin.";
            }
            return View(photo);
        }
    }

}


using Microsoft.AspNetCore.Mvc;
using Modelo;
using Repository;

namespace Aula05Projeto.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment environment;

        private ProductRepository _productRepository;

        public ProductController(IWebHostEnvironment environment)
        {
            _productRepository = new ProductRepository();
            this.environment = environment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Product> product =
                _productRepository.RetriveAll();
            return View(product);
        }

        [HttpPost]
        public IActionResult Create(Product p)
        {
            _productRepository.Save(p);

            List<Product> products = _productRepository.RetriveAll();

            return View("Index", products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ExportDelimitatedFile()
        {
            string fileContent = string.Empty;

            foreach (Product p in CustomerData.Products)
            {
                fileContent += @$"{p.Id};
                                    {p.ProductName};
                                    {p.Description};
                                    R$ {p.CurrentPrice}
                                    \n
                                ";
            }

            var path = Path.Combine(
                environment.WebRootPath,
                "TextFiles"
            );

            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            var filepath = Path.Combine(
                path,
                "Delimitado.txt"
            );

            using (StreamWriter sw = System.IO.File.CreateText(filepath))
            {
                sw.Write(fileContent);
            }

            return View();
        }
    }
}

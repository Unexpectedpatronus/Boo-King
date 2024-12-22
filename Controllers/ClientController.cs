using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; // Подключаем логгер

namespace BookingSystem.Controllers
{
    public class ClientController : Controller
    {
        private readonly BookingContext _context;
        private readonly ILogger<ClientController> _logger; // Добавляем логгер

        public ClientController(BookingContext context, ILogger<ClientController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Заглушка для отображения списка клиентов
        public async Task<IActionResult> Index()
        {
            // Заглушка возвращает пустой список
            var clients = new List<Client>();
            return View(clients); // Здесь предполагается, что существует представление "Index"
        }

        // Заглушка для отображения формы создания клиента (GET)
        public IActionResult Create()
        {
            ViewBag.Tariffs = new List<Tariff>(); // Заглушка для пустого списка тарифов
            return View(); // Здесь предполагается, что существует представление "Create"
        }

        // Заглушка для обработки данных формы создания клиента (POST)
        [HttpPost]
        public async Task<IActionResult> Create(Client client)
        {
            // Логирование для тестирования и заглушка для валидации
            _logger.LogInformation("Метод Create (POST) был вызван.");

            // Проверка валидности данных
            if (!ModelState.IsValid)
            {
                // Заглушка логирует ошибку валидации
                _logger.LogError("Ошибка валидации.");

                // Возвращаем пустой список тарифов и модель с ошибками
                ViewBag.Tariffs = new List<Tariff>();
                return View(client); // Возвращаем форму с данными клиента
            }

            // Заглушка добавления клиента: сохраняем лог вместо добавления в базу данных
            _logger.LogInformation("Клиент успешно добавлен в базу данных (заглушка).");
            return RedirectToAction(nameof(Index)); // Перенаправляем на заглушку списка клиентов
        }

        // Заглушка для отображения деталей клиента (GET)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Возвращаем 404 Not Found, если id не передано
            }

            // Заглушка для поиска клиента по идентификатору
            var client = new Client
            {
                Id = id.Value,
                Name = "Заглушка клиента",
                TariffId = 1,
            };

            // Логируем действие
            _logger.LogInformation("Заглушка вызвана для метода Details.");

            return View(client); // Здесь предполагается, что существует представление "Details"
        }
    }
}

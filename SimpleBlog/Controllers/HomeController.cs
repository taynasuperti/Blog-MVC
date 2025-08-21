using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Models;

namespace SimpleBlog.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private List<Categoria> categorias;
    private List<Postagem> postagens;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        Categoria suspense = new();
        suspense.Id = 1;
        suspense.Nome = "Terror";

        Categoria terror = new()
        {
            Id = 2,
            Nome = "Suspense"
        };

        Categoria acao = new()
        {
            Id = 3,
            Nome = "Ação"
        };

        Categoria ficcao = new()
        {
            Id = 4,
            Nome = "Ficção"
        };

        postagens = [
     new() {
        Id = 1,
        Nome = "American Horror Story",
        CategoriaId = 1,
        Categoria = terror,
        DataPostagem = DateTime.Parse("01/08/2025"),
        Descricao = "Terror psicológico e sobrenatural em diferentes histórias assustadoras.",
        Texto = "American Horror Story é uma série antológica que apresenta uma nova história de terror a cada temporada. Desde casas mal-assombradas até hospícios e seitas, cada enredo mergulha em um tipo de medo diferente. A produção é conhecida por seu estilo visual impactante, atuações intensas e críticas sociais sutis.",
        Thumbnail = "/img/american-horror.jpg",
        Foto = "/img/american-horror.jpg"
    },
    new() {
        Id = 2,
        Nome = "The Walking Dead",
        CategoriaId = 1,
        Categoria = terror,
        DataPostagem = DateTime.Parse("03/08/2025"),
        Descricao = "O apocalipse zumbi que virou fenômeno mundial.",
        Texto = "The Walking Dead acompanha um grupo de sobreviventes em um mundo devastado por zumbis. A série vai além do terror, explorando a natureza humana, dilemas morais e o preço da sobrevivência. Ao longo das temporadas, se destaca por seu desenvolvimento de personagens e momentos icônicos.",
        Thumbnail = "/img/the-walking-dead.webp",
        Foto = "/img/the-walking-dead.webp"
    },
    new() {
        Id = 3,
        Nome = "Ruptura",
        CategoriaId = 2,
        Categoria = suspense,
        DataPostagem = DateTime.Parse("05/08/2025"),
        Descricao = "Trabalho e vida pessoal separados por uma cirurgia misteriosa.",
        Texto = "Em Ruptura, funcionários de uma empresa tecnológica se submetem a um procedimento que separa suas memórias profissionais das pessoais. A série é envolvente e perturbadora, trazendo questionamentos sobre identidade, ética no trabalho e a fragilidade da consciência humana.",
        Thumbnail = "/img/ruptura.jpg",
        Foto = "/img/ruptura.jpg"
    },
    new() {
        Id = 4,
        Nome = "Pretty Little Liars",
        CategoriaId = 2,
        Categoria = suspense,
        DataPostagem = DateTime.Parse("07/08/2025"),
        Descricao = "Segredos, ameaças e mistério entre adolescentes de Rosewood.",
        Texto = "Pretty Little Liars segue a vida de quatro amigas assombradas pelo desaparecimento de sua líder e por mensagens ameaçadoras de alguém chamado 'A'. A série mistura drama adolescente com muito suspense, reviravoltas e intrigas que prendem a atenção do início ao fim.",
        Thumbnail = "/img/pretty-little-liars.jpg",
        Foto = "/img/pretty-little-liars.jpg"
    },
    new() {
        Id = 5,
        Nome = "Supernatural",
        CategoriaId = 3,
        Categoria = acao,
        DataPostagem = DateTime.Parse("09/08/2025"),
        Descricao = "Dois irmãos enfrentando demônios, monstros e o sobrenatural.",
        Texto = "Supernatural acompanha os irmãos Winchester em sua jornada para caçar criaturas sobrenaturais, enfrentar o apocalipse e lidar com seus próprios demônios. Com 15 temporadas, a série se tornou um marco da cultura pop, misturando ação, humor, drama e mitologia.",
        Thumbnail = "/img/supernatural.jpg",
        Foto = "/img/supernatural.jpg"
    },
    new() {
        Id = 6,
        Nome = "Contagem Regressiva",
        CategoriaId = 3,
        Categoria = acao,
        DataPostagem = DateTime.Parse("11/08/2025"),
        Descricao = "Ação intensa e uma corrida contra o tempo.",
        Texto = "Contagem Regressiva é uma série repleta de adrenalina, onde cada episódio coloca seus personagens diante de decisões críticas em situações-limite. Com ritmo acelerado e reviravoltas constantes, prende o espectador do começo ao fim.",
        Thumbnail = "/img/contagem-regressiva.jpg",
        Foto = "/img/contagem-regressiva.jpg"
    },
    new() {
        Id = 7,
        Nome = "Stranger Things",
        CategoriaId = 4,
        Categoria = ficcao,
        DataPostagem = DateTime.Parse("13/08/2025"),
        Descricao = "Amizade, poderes sobrenaturais e anos 80 em uma história envolvente.",
        Texto = "Stranger Things se passa em uma cidade pequena onde crianças desaparecem e eventos estranhos ocorrem. Um portal para uma dimensão paralela, conhecida como Mundo Invertido, é descoberto, trazendo ameaças misteriosas. A série é um sucesso global por sua mistura de ficção científica, terror e nostalgia dos anos 80.",
        Thumbnail = "/img/stranger-things.jpg",
        Foto = "/img/stranger-things.jpg"
    },
    new() {
        Id = 8,
        Nome = "Sandman",
        CategoriaId = 4,
        Categoria = ficcao,
        DataPostagem = DateTime.Parse("15/08/2025"),
        Descricao = "O Senhor dos Sonhos em uma jornada para restaurar seu reino.",
        Texto = "Baseada na aclamada HQ de Neil Gaiman, Sandman narra a história de Morpheus, a entidade que governa os sonhos. Após ser aprisionado por décadas, ele precisa recuperar seus artefatos e restaurar a ordem do mundo onírico. A série combina fantasia, filosofia e visuais impressionantes.",
        Thumbnail = "/img/sandman.jpeg",
        Foto = "/img/sandman.jpeg"
    }
 ];

    }

    public IActionResult Index()
    {
        return View(postagens);
    }

    public IActionResult Postagem(int id)
    {
        var postagem = postagens
            .Where(p => p.Id == id)
            .SingleOrDefault();
        if(postagem == null)
            return NotFound();
        return View(postagem);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

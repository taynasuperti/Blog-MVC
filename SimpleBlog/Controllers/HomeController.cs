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
        Texto = "<b>Gênero: </b> Terror, suspense, drama. </br> <b>Formato:</b> Série antológica (cada temporada tem uma história diferente). </br> <b>Sinopse:</b> Criada por Ryan Murphy e Brad Falchuk, cada temporada mergulha em um universo sombrio e independente — mansões assombradas, hospitais psiquiátricos, circos de aberrações, hotéis macabros, cultos sinistros e até o apocalipse. A série é conhecida por seu elenco recorrente e por misturar horror psicológico com crítica social. </br> <b>Onde assistir: </b> Star+",
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
        Texto = "<b>Gênero: </b>Drama, terror, apocalipse zumbi</br> <b>Sinopse:</b> Após acordar de um coma, o xerife Rick Grimes descobre que o mundo foi devastado por uma infestação de zumbis. Ele se junta a um grupo de sobreviventes em busca de segurança, enfrentando não só os mortos-vivos, mas também os perigos dos próprios humanos. A série explora os limites da sobrevivência e da moral em um mundo sem regras. </br> <b>Onde assistir: </b>Disney+ e Netflix ",
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
        Texto = "<b>Gênero: </b>Suspense psicológico, ficção científica. </br ><b>Sinopse:</b> Funcionários da misteriosa empresa Lumon passam por um procedimento que separa completamente suas memórias pessoais das profissionais. Dentro do trabalho, não sabem quem são fora dali — e vice-versa. Quando Mark começa a desconfiar dos verdadeiros propósitos da empresa, inicia uma jornada perturbadora sobre identidade, controle e liberdade. </br> <b>Onde assistir: </b>Apple TV+",
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
        Texto = "<b>Gênero: </b>Drama, mistério, suspense adolescente. </br><b>Sinopse:</b> Em Rosewood, quatro amigas tentam seguir com suas vidas após o desaparecimento de Alison, a líder do grupo. Um ano depois, começam a receber mensagens ameaçadoras de alguém que assina como “A”, revelando segredos que só Alison conhecia. A série mistura romance, intrigas e muitos mistérios ao longo de suas oito temporadas. </br> <b>Onde assistir: </b> HBO MAX",
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
        Texto = "<b>Gênero: </b>Terror, fantasia, ação. </br> <b>Sinopse:</b> Sam e Dean Winchester são irmãos que percorrem os Estados Unidos caçando criaturas sobrenaturais — demônios, fantasmas, vampiros e muito mais. Após a morte misteriosa da mãe, eles seguem os passos do pai e mergulham em uma guerra entre o bem e o mal que envolve anjos, demônios e até o próprio apocalipse. </br> <b>Onde assistir: </b>Prime Video, HBO Max",
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
        Texto = "<b>Gênero: </b>Suspense policial, ação. </br> <b>Sinopse:</b> Um agente do Departamento de Segurança Interna é assassinado em plena luz do dia, e o detetive Mark Meachum (Jensen Ackles) é convocado para uma força-tarefa secreta. O que começa como uma investigação simples se transforma em uma corrida contra o tempo para impedir um ataque terrorista que ameaça milhões. </br> <b>Onde assistir: </b>Amazon Prime Video",
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
        Texto = "<b>Gênero: </b>Ficção científica, suspense, drama.  </br> <b>Sinopse:</b> Na pacata cidade de Hawkins, Indiana, nos anos 80, um garoto desaparece misteriosamente. Enquanto sua mãe e amigos o procuram, descobrem uma garota com poderes telecinéticos e um portal para uma dimensão sombria chamada Mundo Invertido. A série mistura nostalgia, mistério e criaturas aterrorizantes. </br> <b>Onde assistir: </b> Netflix",
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
        Texto = "<b>Gênero: </b>Fantasia, drama. </br> <b>Sinopse:</b> Morpheus, o Rei dos Sonhos, é capturado por um mago que tentava aprisionar a Morte. Após décadas preso, ele escapa e parte em busca de seus artefatos mágicos para restaurar seu reino. Baseada nos quadrinhos de Neil Gaiman, a série mergulha em temas como mitologia, sonhos e o equilíbrio entre mundos. </br> <b>Onde assistir: </b>Netflix",
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

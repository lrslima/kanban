using System.ComponentModel.DataAnnotations;
using kanban_backed.Business.Models;
using kanban_backend.DTOs;

namespace kanban_backend.Tests;

public class UnitTest1
{
    [Fact]
    public void Card_Constructor_SetsProperties()
    {
        // Arrange
        int id = 1;
        string titulo = "Teste Título";
        string conteudo = "Teste Conteúdo";
        string lista = "Teste Lista";

        // Act
        Card card = new Card(id, titulo, conteudo, lista);

        // Assert
        Assert.Equal(id, card.Id);
        Assert.Equal(titulo, card.Titulo);
        Assert.Equal(conteudo, card.Conteudo);
        Assert.Equal(lista, card.Lista);
    }

    [Fact]
    public void MapFromDto_ValidDto_ReturnsCardModel()
    {
        // Arrange
        var dto = new CardDTO
        {
            Id = 1,
            Titulo = "Teste Título",
            Conteudo = "Teste Conteúdo",
            Lista = "Teste Lista"
        };

        var viewModel = new CardDTO();

        // Act
        var result = viewModel.MapFromDto(dto);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<Card>(result);
        Assert.Equal(dto.Id, result.Id);
        Assert.Equal(dto.Titulo, result.Titulo);
        Assert.Equal(dto.Conteudo, result.Conteudo);
        Assert.Equal(dto.Lista, result.Lista);
    }

    [Fact]
    public void MapFromDto_NullDto_ReturnsNull()
    {
        // Arrange
        var viewModel = new CardDTO();
        viewModel.Titulo = "titulo";
        viewModel.Lista = "lista";
        viewModel.Conteudo = "conteudo";

        // Act
        var result = viewModel.MapFromDto(viewModel);

        // Assert
        Assert.Equal(result.Conteudo, viewModel.Conteudo);
        Assert.Equal(result.Lista, viewModel.Lista);
        Assert.Equal(result.Titulo, viewModel.Titulo);

    }

    [Fact]
    public void ViewModel_Properties_HaveRequiredAttribute()
    {
        // Arrange
        var viewModel = new CardDTO();

        // Act
        var tituloProperty = viewModel.GetType().GetProperty(nameof(CardDTO.Titulo));
        var conteudoProperty = viewModel.GetType().GetProperty(nameof(CardDTO.Conteudo));
        var listaProperty = viewModel.GetType().GetProperty(nameof(CardDTO.Lista));

        // Assert
        Assert.NotNull(tituloProperty);
        Assert.NotNull(conteudoProperty);
        Assert.NotNull(listaProperty);

        var tituloAttribute = tituloProperty.GetCustomAttributes(typeof(RequiredAttribute), false);
        var conteudoAttribute = conteudoProperty.GetCustomAttributes(typeof(RequiredAttribute), false);
        var listaAttribute = listaProperty.GetCustomAttributes(typeof(RequiredAttribute), false);

        Assert.Single(tituloAttribute);
        Assert.Single(conteudoAttribute);
        Assert.Single(listaAttribute);
    }
}

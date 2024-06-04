using ProjetoWeb;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<Database>();

var app = builder.Build();

app.MapGet("/BuscarQuantidade/{codigo}", (
    string codigo,
    Database db
) =>
{
    Produto? produto = db.Produtos
        .Where(e => e.Codigo == codigo)
        .FirstOrDefault();

    if (produto == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(produto.Quantidade);
});

app.MapPatch("/RemoverProduto/{codigo}", (
    string codigo,
    Database db
) =>
{
    Produto? produto = db.Produtos
        .Where(e => e.Codigo == codigo)
        .FirstOrDefault();

    if (produto == null)
    {
        return Results.NotFound();
    }

    if (produto.Quantidade <= 0)
    {
        return Results.BadRequest("Quantidade já é mínima");
    }

    produto.Quantidade -= 1;

    return Results.Ok();
});

app.MapPost("/AdicionarProduto/{codigo}", (
    string codigo,
    Database db
) =>
{
    Produto? produto = db.Produtos
        .Where(e => e.Codigo == codigo)
        .FirstOrDefault();

    if (produto == null)
    {
        return Results.NotFound();
    }

    produto.Quantidade += 1;

    return Results.Ok();
});

app.Run();

using GraphQLAPI.Models;

namespace GraphQLAPI;

public class Mutation
{ 

    // For SupreHero
    [GraphQLName("AddSupreHreo")]
    [UseDbContext(typeof(SuperHeroDbContext))]
    public async Task<Superhero> AddSuperHeroAsync(AddSuperHero input, [ScopedService] SuperHeroDbContext context,
       CancellationToken token)
    {
        var superhero = new Superhero
        {
            Id = Guid.NewGuid(),
            Name = input.Name,
            Description = input.Description,
            Height = input.Height

        };

        await context.Superheroes.AddAsync(superhero, token);
        await context.SaveChangesAsync(token);
        return superhero;
    }

    [GraphQLName("UpdateSuperHero")]
    [UseDbContext(typeof(SuperHeroDbContext))]
    public async Task<Superhero> UpdateSuperHeroAsync(Superhero input, [ScopedService] SuperHeroDbContext context,
        CancellationToken token)
    {
        var superhero = await context.Superheroes.FindAsync(input.Id);

        if (superhero is not null)
        {
            superhero.Name = input.Name;
            superhero.Description = input.Description;
            superhero.Height = input.Height;
        }
        else
        {
            return null;
        }

        context.Superheroes.Update(superhero);
        await context.SaveChangesAsync(token);

        return superhero;
    }


    // For Suprepower
    [GraphQLName("AddSuprepower")]
    [UseDbContext(typeof(SuperHeroDbContext))]
    public async Task<Superpower> AddSuperPowerAsync(AddSuperpower input, [ScopedService] SuperHeroDbContext context,
       CancellationToken token)
    {
        var superpower = new Superpower
        {
            Id = Guid.NewGuid(),
            SuperPower = input.SuperPower,
            Description = input.Description,
            

        };

        await context.Superpowers.AddAsync(superpower, token);
        await context.SaveChangesAsync(token);
        return superpower;
    }

    [GraphQLName("UpdateSuperPower")]
    [UseDbContext(typeof(SuperHeroDbContext))]
    public async Task<Superpower> UpdateSuperPowerAsync(Superhero input, [ScopedService] SuperHeroDbContext context,
        CancellationToken token)
    {
        var superpower = await context.Superpowers.FindAsync(input.Id);

        if (superpower is not null)
        {
            superpower.Description = input.Description;
            superpower.SuperheroId = Guid.NewGuid();
           
        }
        else
        {
            return null;
        }

        context.Superpowers.Update(superpower);
        await context.SaveChangesAsync(token);

        return superpower;
    }
}

namespace Smdb.Core.Db;

using Smdb.Core.Movies;

using Smdb.Core.Actors;

using Smdb.Core.Users;

using Smdb.Core.ActorMovie;

public class MemoryDatabase
{
    public List<Movie> Movies { get; }

    private int nextMovieId;

    public MemoryDatabase()
    {
        Movies = [];
        Actors = [];
        Users = [];

        SeedMovies();
        SeedActors();
        SeedUsers();

        nextMovieId = Movies.Count;
        nextActorId = Actors.Count;
        nextUserId = Users.Count;
        
    }

    private void SeedMovies()
    {
        Movies.AddRange(new Movie[]
        {
            new Movie(1, "The Godfather", 1972, "A mafia patriarch hands the family empire to his reluctant son."), 
            new Movie(2, "The Godfather Part II", 1974, "Michael consolidates power as flashbacks trace Vito Corleone’s rise."),
            new Movie(3, "The Dark Knight", 2008, "Batman faces the Joker, who pushes Gotham into chaos."),
            new Movie(4, "The Shawshank Redemption", 1994, "An innocent banker forms a life-saving friendship in prison."),
            new Movie(5, "Pulp Fiction", 1994, "Interlocking LA crime stories unfold with dark humor."),
            new Movie(6, "Schindler's List", 1993, "A businessman saves Jewish workers during the Holocaust."),
            new Movie(7, "The Lord of the Rings: The Return of the King", 2003, "The final push to destroy the One Ring decides Middle-earth’s fate."),
            new Movie(8, "Fight Club", 1999, "An insomnia-plagued worker joins a charismatic anarchist’s secret club."),
            new Movie(9, "Forrest Gump", 1994, "A kind man unwittingly drifts through historic American moments."),
            new Movie(10, "Inception", 2010, "A thief enters dreams to plant an idea in a target’s mind."),
            new Movie(11, "The Matrix", 1999, "A hacker learns reality is a simulated prison for humanity."),
            new Movie(12, "Se7en", 1995, "Two detectives hunt a killer using the seven deadly sins."),
            new Movie(13, "Goodfellas", 1990, "Henry Hill’s rise and fall inside the New York mob."),
            new Movie(14, "The Silence of the Lambs", 1991, "An FBI trainee consults Hannibal Lecter to catch a serial killer."),
            new Movie(15, "Star Wars: Episode IV – A New Hope", 1977, "A farm boy joins rebels to destroy the Empire’s Death Star."),
            new Movie(16, "The Empire Strikes Back", 1980, "The Rebels scatter as Luke confronts Darth Vader."),
            new Movie(17, "Interstellar", 2014, "Astronauts travel through a wormhole to save a dying Earth."),
            new Movie(18, "Parasite", 2019, "A poor family infiltrates a wealthy household with unforeseen fallout."),
            new Movie(19, "Spirited Away", 2001, "A girl navigates a spirit bathhouse to free her parents."),
            new Movie(20, "City of God", 2002, "Two boys take diverging paths amid Rio’s gang wars."),
            new Movie(21, "Saving Private Ryan", 1998, "A squad risks everything to bring a paratrooper home."),
            new Movie(22, "The Green Mile", 1999, "Death-row guards encounter a prisoner with miraculous gifts."),
            new Movie(23, "Gladiator", 2000, "A betrayed general becomes Rome’s fiercest arena fighter."),
            new Movie(24, "The Lion King", 1994, "An exiled lion cub returns to claim his destiny."),
            new Movie(25, "Back to the Future", 1985, "A teen time-travels and risks erasing his own existence."),
            new Movie(26, "The Departed", 2006, "An infiltrator and a mole play cat- and - mouse in Boston."),
            new Movie(27, "Whiplash", 2014, "A jazz drummer endures a brutal mentor in pursuit of greatness."),
            new Movie(28, "The Prestige", 2006, "Rival magicians wage a dangerous war of one - upmanship."),
            new Movie(29, "The Usual Suspects", 1995, "A survivors’ tale hints at the legend of Keyser Söze."),
            new Movie(30, "Terminator 2: Judgment Day", 1991, "A reprogrammed cyborg protects the future leader of humanity."),
            new Movie(31, "Alien", 1979, "A crew is stalked by a lethal lifeform aboard a spaceship."),
            new Movie(32, "Aliens", 1986, "Ripley returns to face a hive of xenomorphs on LV - 426."),
            new Movie(33, "Blade Runner", 1982, "A detective hunts rogue androids in a neon - soaked future."),
            new Movie(34, "Apocalypse Now", 1979, "A captain journeys upriver to terminate a renegade officer."),
            new Movie(35, "One Flew Over the Cuckoo's Nest", 1975, "A rebel patient challenges a tyrannical nurse in a psych ward."),
            new Movie(36, "Taxi Driver", 1976, "A disturbed NYC cabbie spirals toward violence."),
            new Movie(37, "Oldboy", 2003, "A man seeks answers after 15 years of inexplicable captivity."),
            new Movie(38, "Amélie", 2001, "A shy Parisian decides to secretly improve others’ lives."),
            new Movie(39, "The Pianist", 2002, "A Jewish pianist struggles to survive Warsaw’s ghetto."),
            new Movie(40, "American Beauty", 1999, "A suburban man’s midlife crisis upends his family."),
            new Movie(41, "No Country for Old Men", 2007, "A stolen briefcase triggers relentless pursuit across Texas."),
            new Movie(42, "There Will Be Blood", 2007, "An oilman’s ambition consumes everything around him."),
            new Movie(43, "Mad Max: Fury Road", 2015, "A desert chase pits a warlord against a defiant road warrior."),
            new Movie(44, "La La Land", 2016, "A musician and an actress chase dreams in modern LA."),
            new Movie(45, "Joker", 2019, "A marginalized comedian’s breakdown sparks violent unrest."),
            new Movie(46, "Avengers: Infinity War", 2018, "Earth’s heroes battle Thanos for the fate of half the universe."),
            new Movie(47, "Avengers: Endgame", 2019, "Survivors attempt a time-heist to undo cosmic devastation."),
            new Movie(48, "Toy Story", 1995, "Rivalry between a cowboy doll and a space ranger turns to friendship."),
            new Movie(49, "Inside Out", 2015, "A girl’s emotions guide her through a difficult move."),
            new Movie(50, "The Social Network", 2010, "Facebook’s founding sparks friendship and legal battles.")
});
    }
    public int NextMovieId()
    {
        return ++nextMovieId;
    }

    //actors

    public List<Actor> Actors { get; }

    private int nextActorId;

    private void SeedActors()
    {
        Actors.AddRange(new Actor[]
        {
            new Actor(1, "Al Pacino", 1940, "American."), 
            new Actor(2, "Robert De Niro", 1943, "American."),
            new Actor(3, "Christian Bale", 1974, "British."),
            new Actor(4, "Morgan Freeman", 1937, "American."),
            new Actor(5, "Quentin Tarantino", 1963, "American."),
            new Actor(6, "Liam Neeson", 1952, "British."),
            new Actor(7, "Elijah Wood", 1981, "American."),
            new Actor(8, "Edward Norton", 1969, "American."),
            new Actor(9, "Tom Hanks", 1956, "American."),
            new Actor(10, "Leonardo DiCaprio", 1974, "American."),
            new Actor(11, "Keanu Reeves", 1964, "Canadian."),
            new Actor(12, "Gwyneth Paltrow", 1972, "American."),
            new Actor(13, "Ray Liotta", 1954, "American."),
            new Actor(14, "Anthony Hopkins", 1937, "British-American."),
            new Actor(15, "Mark Hamill", 1951, "American."),
            new Actor(16, "Harrison Ford", 1942, "American."),
            new Actor(17, "Matthew McConaughey", 1969, "American."),
            new Actor(18, "Cho Yeo-jeong", 1981, "Korean."),
            new Actor(19, "Rumi Hiiragi", 1987, "Japanese."),
            new Actor(20, "Alice Braga", 1983, "Brazilian."),
            new Actor(21, "Matt Damon", 1970, "American."),
            new Actor(22, "Michael Clarke Duncan", 1957, "American."),
            new Actor(23, "Russell Crowe", 1964, "New Zealander."),
            new Actor(24, "Matthew Broderick", 1962, "American."),
            new Actor(25, "Michael J. Fox", 1961, "American-Canadian."),
            new Actor(26, "Vera Farmiga", 1973, "American."),
            new Actor(27, "Miles Teller", 1987, "American."),
            new Actor(28, "Hugh Jackman", 1968, "British-Australian."),
            new Actor(29, "Kevin Spacey", 1959, "American."),
            new Actor(30, "Edward Furlong", 1977, "American."),
            new Actor(31, "Sigourney Weaver", 1949, "American."),
            new Actor(32, "Carrie Henn", 1976, "American."),
            new Actor(33, "Harrison Ford", 1942, "American."),
            new Actor(34, "Martin Sheen", 1940, "American."),
            new Actor(35, "Jack Nicholson", 1937, "American."),
            new Actor(36, "Robert De Niro", 1943, "American."),
            new Actor(37, "Kang Hye-jung", 1982, "Korean."),
            new Actor(38, "Audrey Tautou", 1976, "French."),
            new Actor(39, "Adrien Brody", 1973, "American."),
            new Actor(40, "Mena Suvari", 1979, "American."),
            new Actor(41, "Javier Bardem", 1969, "Spanish."),
            new Actor(42, "Daniel Day-Lewis", 1957, "English."),
            new Actor(43, "Tom Hardy", 1977, "English."),
            new Actor(44, "Emma Stone", 1988, "American."),
            new Actor(45, "Heath Ledger", 1979, "Australian."),
            new Actor(46, "Robert Downey Jr.", 1965, "American."),
            new Actor(47, "Scarlett Johansson", 1984, "American."),
            new Actor(48, "Tim Allen", 1953, "American."),
            new Actor(49, "Mary Gibbs", 1996, "American."),
            new Actor(50, "Jesse Eisenberg", 1983, "American.")
});
    }
    public int NextActorId()
    {
        return ++nextActorId;
    }

    //users

    public List<User> Users { get; }

    private int nextUserId;

    private void SeedUsers()
    {
        Users.AddRange(new User[]
        {
            new User(1, "Maria García", 1940, "mgarcía9867@interbayamon.edu"), 
            new User(2, "González", 2003, "sgonzález2343@interbayamon.edu"),
            new User(3, "Smith", 1974, "nsmith6545@interbayamon.edu"),
            new User(4, "Wang", 2004, "wwang5456@interbayamon.edu"),
            new User(5, "Mohamed", 1963, "hmohamed8032@interbayamon.edu"),
            new User(6, "Kim", 1952, "ykim4970@interbayamon.edu"),
            new User(7, "lopéz", 1981, "slopez4764@interbayamon.edu"),
            new User(8, "Rodriguez", 1969, "jrodriguez9873@interbayamon.edu"),
            new User(9, "González", 1956, "vgonzalez2254@interbayamon.edu"),
            new User(10, "Rivera", 1974, "jrivera9873@interbayamon.edu"),
            new User(11, "Rivera", 1964, "arivera0013@interbayamon.edu"),
            new User(12, "Sanchez", 1972, "jsanchez6041@interbayamon.edu"),
            new User(13, "Diaz", 1954, "cdiaz3983@interbayamon.edu"),
            new User(14, "Narvaez", 1937, "inarvaez8865@interbayamon.edu"),
            new User(15, "Rivera", 1999, "arivera6241@interbayamon.edu"),
            new User(16, "García", 1942, "vgarcia4047@interbayamon.edu"),
            new User(17, "Sanchez", 1969, "vsanchez5235@interbayamon.edu"),
            new User(18, "Nieves", 1981, "cnieves4534@interbayamon.edu"),
            new User(19, "Maldonado", 1994, "gmaldonado7098@interbayamon.edu"),
            new User(20, "Diaz", 1983, "ddiaz6541@interbayamon.edu"),
            new User(21, "Damon", 2008, "mdamon0808@interbayamon.edu"),
            new User(22, "Mia Maldonado", 1957, "mmaldonado5791@interbayamon.edu"),
            new User(23, "Rosa Vega", 1964, "rvega6914@interbayamon.edu"),
            new User(24, "Marcos Acosta", 1962, "macosta9622@interbayamon.edu"),
            new User(25, "Luz Nieves", 1961, "lnieves6191@interbayamon.edu"),
            new User(26, "Margaita Lee", 1973, "lmargarita4373@interbayamon.edu"),
            new User(27, "Mili Torres", 1987, "mtorres@9187@interbayamon"),
            new User(28, "Grecia Martínez", 1968, "gmartinez8645@interbayamon.edu"),
            new User(29, "Kevin Ford", 1959, "kford9564@interbayamon.edu"),
            new User(30, "Edward de Jesus", 1977, "edejesus7766@interbayamon.edu"),
            new User(31, "Sinny Weaver", 1949, "sweader9073@interbayamon.edu"),
            new User(32, "Mozard Hernandez", 1976, "mhernandez6722@interbayamon.edu"),
            new User(33, "Pablo Figueroa", 1942, "pfigueroa5362@interbayamon.edu"),
            new User(34, "Alberto Landró", 1940, "alandro1290@interbayamon.edu"),
            new User(35, "Jose Pardo", 1993, "jpardo5673@interbayamon.edu"),
            new User(36, "Hiro Febus", 1943, "hfebus3782@interbayamon.edu"),
            new User(37, "Elizabeth Perez", 1992, "eperez1039@interbayamon.edu"),
            new User(38, "Naomi Alisea", 1976, "nalisea1973@interbayamon.edu"),
            new User(39, "Barbara Martinez", 1973, "gmartinez1983@interbayamon.edu"),
            new User(40, "Cristofer Gonzalez", 1979, "cgonzales8436@interbayamon.edu"),
            new User(41, "Javier Melendez", 1969, "jmelendez2984@interbayamon.edu"),
            new User(42, "Daniel Padró", 2003, "dpadro3476@interbayamon.edu"),
            new User(43, "Tom Pagán", 1977, "tpagan8476@interbayamon.edu"),
            new User(44, "Emma Collazo", 1988, "ecollazo3875@interbayamon.edu"),
            new User(45, "Katerine Belmudez", 1999, "kbelmudez5683@interbayamon.edu"),
            new User(46, "Robert Escobar", 1965, "rescobar0495@interbayamon.edu"),
            new User(47, "Eileen Navarro", 1984, "enavarro4638@interbayamon.edu"),
            new User(48, "Maryely Ramirez", 1995, "mramirez7358@interbayamon.edu"),
            new User(49, "Isaac García", 1996, "igarcia9823@interbayamon.edu"),
            new User(50, "Marissa Colón", 1983, "mcolon4678@interbayamon.edu")
});
    }
    public int NextUserId()
    {
        return ++nextUserId;
    }






    
}
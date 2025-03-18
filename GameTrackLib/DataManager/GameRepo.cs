using System.Text.Json;
using GameTrackLib.Model;

namespace GameTrackLib.DataManager;

/// <summary>
/// Classes rassemblant toutes
/// </summary>
public static class GameRepo
{
    private static JsonDB<GameTrace> _db = new JsonDB<GameTrace>("./userdata/games.json");
    
    /// <summary>
    /// Récupère tout les jeux dans la db
    /// </summary>
    /// <returns></returns>
    public static List<GameTrace> GetGames()
    {
        return _db.Load();
    }

    /// <summary>
    /// Récupère un jeu à partir de son ID
    /// </summary>
    /// <param name="gameId">Identifiant du jeu</param>
    /// <returns>Le jeu identifié par <paramref name="gameId"/></returns>
    public static GameTrace GetGame(int gameId)
    {
        return _db.Load().Single(g => g.Id == gameId);
    }

    /// <summary>
    /// Ajoute un jeu à la liste de jeu à tracker
    /// </summary>
    /// <param name="game">Le jeu à ajouter à la "db"</param>
    /// <returns>L'identifiant du jeu en db</returns>
    public static int AddGame(GameTrace game)
    {
        var games = _db.Load();
        game.Id = games.Max(g => g.Id) + 1;
        games.Add(game);
        _db.Save(games);
        return game.Id;
    }

    /// <summary>
    /// Supprime un jeu de la db
    /// </summary>
    /// <param name="gameId">Identifiant du jeu à supprimer</param>
    public static void DeleteGame(int gameId)
    {
        var games = _db.Load();
        games.Remove(games.Single(g => g.Id == gameId));
        _db.Save(games);
    }
    
    /// <summary>
    /// Mets à jour le temps passé sur un jeu
    /// </summary>
    /// <param name="id">L'identifiant du jeu à mettre à jour</param>
    /// <param name="timeToAdd">Le temps ajouté à celui existant en db</param>
    public static void UpdateGame(int id,TimeSpan timeToAdd)
    {
        var games = _db.Load();
        games[id].Time += timeToAdd;
        _db.Save(games);
    }
}
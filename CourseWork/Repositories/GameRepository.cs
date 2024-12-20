﻿using CourseWork;

public class GameRepository(DbContext context) : IGameRepository
{
    public void AddGameRecord(GameData record)
    {
        record.Id = context.GameDatas.Count + 1;
        context.GameDatas.Add(record);
    }

    public IEnumerable<GameData> GetUserGames(string username)
    {
        return context.GameDatas.FindAll(g => g.User.Username == username);
    }
}
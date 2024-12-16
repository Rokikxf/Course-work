﻿using CourseWork;

public interface IGameRepository
{
    void AddGameRecord(GameData record);
    IEnumerable<GameData> GetUserGames(int userId);
}
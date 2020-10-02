using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Enums;
using Sokoban.Infrastructure.Interfaces.Proxy;

namespace Sokoban.Proxy
{
    public class LevelProviderProxy : ILevelProvider
    {
        private ILevelProvider originalProvider;
        private int bestDifficultyRequested;
        private IDictionary<int, ComponentsEnum[,]> m_cache;
        public LevelProviderProxy()
        {
            originalProvider = new LevelProvider();     // Creating the Original Level Provider 
            bestDifficultyRequested = 0;               // No diffculty is requested yet
            m_cache = new Dictionary<int, ComponentsEnum[,]>();     // Creating a cache to not overload the server
        }
        public ComponentsEnum[,] GetLevel(int difficulty)
        {
            ComponentsEnum[,] level;
            // If the user has requested a difficulty not one level above
            if (bestDifficultyRequested + 1 < difficulty)
            {
                difficulty = bestDifficultyRequested;       // Reset the request difficulty
            }
            
            // Checking if the proxy already contain the level in it's cache
            if(!m_cache.TryGetValue(difficulty, out level))
            {
                level = originalProvider.GetLevel(difficulty);      // Request the level from the server
                m_cache.Add(difficulty, level);                     // Adding the level to the cache
            }
            bestDifficultyRequested = difficulty;                   // Storing the last requestes level
            return level;       // Return the level
        }

        public bool HasLevel(int level)
        {
            // If the level was seen before
            if(m_cache.ContainsKey(level))
                return true;
            return originalProvider.HasLevel(level);
        }
    }
}

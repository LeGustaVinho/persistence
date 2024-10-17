using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LegendaryTools.Persistence
{
    public interface IPersistence : IDisposable
    {
        public bool IsBusy { get; }
        string Set<T>(T dataToSave, string id = Persistence.EMPTY_ID, int version = 0, bool autoSave = false);
        T Get<T>(string id);
        (int, int, DateTime) GetMetadata<T>();
        Dictionary<string, T> GetCollection<T>();
        bool Delete<T>(string id, bool autoSave = false);
        bool Contains<T>(string id);
        void Save();
        void Load();
        Task SaveAsync();
        Task LoadAsync();
        void AddListener<T>(Action<IPersistence, PersistenceAction, string, object> callback);
        void RemoveListener<T>(Action<IPersistence, PersistenceAction, string, object> callback);
    }
}
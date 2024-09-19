# Persistence System

An easy-to-use and extensible data persistence system for Unity, inspired by PlayerPrefs. This system provides a flexible API with support for custom serialization, storage, and encryption providers. All data is compressed using Gzip to optimize storage space.

### How to install

#### - From OpenUPM:

- Open **Edit -> Project Settings -> Package Manager**
- Add a new Scoped Registry (or edit the existing OpenUPM entry)

| Name  | package.openupm.com  |
| ------------ | ------------ |
| URL  | https://package.openupm.com  |
| Scope(s)  | com.legustavinho  |

- Open Window -> Package Manager
- Click `+`
- Select `Add package by name...`
- Paste `com.legustavinho.legendary-tools-persistence` and click `Add`

#### Features
- Easy to Use: Simple API similar to Unity's PlayerPrefs.
- Extensible API:
    - Serialization Providers: Customize how data is serialized.
    - Saving Providers: Define where data is saved.
    - Encryption Providers: Implement custom encryption for secure data storage.
- Data Compression: Data is compressed using Gzip for efficient storage.
- Built In serializers implemented out of box:
    - [Nido Serializer](https://github.com/LeGustaVinho/nido-serializer "Nido Serializer") (Odin Serializer fork)
    - [Unity Newtonsoft.JSON](https://docs.unity3d.com/Packages/com.unity.nuget.newtonsoft-json@3.2/manual/index.html "Unity Newtonsoft.JSON")
    - Binary
    - XML


#### Getting Started
To begin using the data persistence system, you'll need to:

1. Initialize the Persistence: Create an instance of the persistence system.
2. Save Data: Use the `Set<T>` method to save data.
3. Load Data: Use the `Get<T>` method to retrieve data.
4. Save to Storage: Call `Save()` or `SaveAsync()` to write data to the storage provider.
5. Load from Storage: Call `Load()` or `LoadAsync()` to read data from the storage provider.

#### API Overview

```csharp
public interface IPersistence
{
    bool IsBusy { get; }
    string Set<T>(T dataToSave, string id = Persistence.EMPTY_ID, int version = 0);
    T Get<T>(string id);
    (int, int, DateTime) GetMetadata<T>();
    Dictionary<string, T> GetCollection<T>();
    bool Delete<T>(string id);
    bool Contains<T>(string id);
    void Save();
    void Load();
    Task SaveAsync();
    Task LoadAsync();
    void AddListener<T>(Action<IPersistence, PersistenceAction, string, object> callback);
    void RemoveListener<T>(Action<IPersistence, PersistenceAction, string, object> callback);
}
```
**Key Methods:**
- `Set<T>(T dataToSave, string id, int version)`: Saves data of type T with an optional id and version.
- `Get<T>(string id)`: Retrieves data of type T using the id.
- `Save()` / `SaveAsync()`: Persists all data to the storage provider.
- `Load()` / `LoadAsync()`: Loads all data from the storage provider.

### Examples
#### Basic Usage

```csharp
// Create an instance of the persistence system
IPersistence persistence = new Persistence();

// Save data
persistence.Set<PlayerData>(playerData, "player1");

// Retrieve data
PlayerData loadedData = persistence.Get<PlayerData>("player1");

// Save all data to storage
persistence.Save();

// Load all data from storage
persistence.Load();
```
#### Contributing
Contributions are welcome! Please open an issue or submit a pull request for any improvements.

#### License
This project is licensed under the MIT License.

using Microsoft.VisualBasic;
using RelayChat.Services.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RelayChat.Services.Infrastructure.Services
{
    public class LocalStorageService 
    {
        //private readonly string _localStoragePath = "local_storage.json";  // Local file path

        //public async Task SaveChatDataAsync(List<Conversation> conversations, List<User> users, List<Media> media)
        //{
        //    var chatData = new
        //    {
        //        Users = users,
        //        Conversations = conversations,
        //        Media = media
        //    };

        //    var json = JsonConvert.SerializeObject(chatData, Formatting.Indented);
        //    await File.WriteAllTextAsync(_localStorageFilePath, json);
        //}



        //// Load conversations from local storage
        //public async Task<List<Conversation>> LoadConversationsAsync()
        //{
        //    if (File.Exists(_localStoragePath))
        //    {
        //        var json = await File.ReadAllTextAsync(_localStoragePath);
        //        return JsonConvert.DeserializeObject<List<Conversation>>(json) ?? new List<Conversation>();
        //    }
        //    return new List<Conversation>();
        //}


    }
}

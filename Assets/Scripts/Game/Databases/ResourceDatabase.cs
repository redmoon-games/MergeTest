using System.Collections.Generic;
using Game.Models;
using UnityEditor;
using UnityEngine;
using Utils;

namespace Game.Databases
{
    [CreateAssetMenu(menuName = "Scriptable Database/ResourceDatabase", fileName = "ResourceDatabase")]
    public class ResourceDatabase : ScriptableObject
    {
        [SerializeField] private List<Image> images;
        
        public Sprite GetImageById(string id) => images.GetBy(value => value.id == id).sprite;

        public void DownloadImages()
        {
#if UNITY_EDITOR
            images = new List<Image>();
            DownloadToList(new[] {"Assets/Sprites/Sweets Icons/Icons with outline"}, images);
            Debug.Log($"[{nameof(ResourceDatabase)}] Update Success");
#endif
        }

        private void DownloadToList(string[] folders, List<Image> destination)
        {
            destination.Clear();
            var sprites = new List<Sprite>();
            var guids = AssetDatabase.FindAssets("t:Texture2D", folders);
            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                sprites.Add((Sprite) AssetDatabase.LoadAssetAtPath(path, typeof(Sprite)));
            }
            
            foreach (var sprite in sprites)
            {
                destination.Add(new Image(){id = sprite.name, sprite = sprite});
            }
        }
    }
}

using System;
using Game.Databases;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Editor.Databases
{
    [CustomEditor(typeof(ResourceDatabase))]
    public class ImageDatabaseEditor : UnityEditor.Editor
    {
        private ResourceDatabase database;

        private void OnEnable()
        {
            database = (ResourceDatabase) target;
        }

        public override VisualElement CreateInspectorGUI()
        {
            var container = new VisualElement();

            CreateButton(Download, "Download");
            
            var iterator = serializedObject.GetIterator();
            if (iterator.NextVisible(true))
            {
                do
                {
                    var propertyField = new PropertyField(iterator.Copy()) { name = "PropertyField:" + iterator.propertyPath };
 
                    if (iterator.propertyPath == "m_Script" && serializedObject.targetObject != null)
                        propertyField.SetEnabled(value: false);
 
                    container.Add(propertyField);
                }
                while (iterator.NextVisible(false));
            }
 
            return container;

            void CreateButton(Action onClick, string label)
            {
                var downloadButton = new Button() { text = label };

                // Gives it some style.
                downloadButton.style.width = container.contentRect.width;
                downloadButton.style.height = 30;
                downloadButton.style.alignSelf = new StyleEnum<Align>(Align.Center);
                downloadButton.clickable.clicked += onClick;
                container.Add(downloadButton);
            }
        }

        private void Download()
        {
            database.DownloadImages();
            EditorUtility.SetDirty(target);
        }
    }
}
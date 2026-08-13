using System.IO;
using BepInEx;
using PerfectRandom.Sulfur.Core.Weapons;
using UnityEngine;
using System.Text.RegularExpressions;

public class ImageHelpers {

    // .............this was a rabbit hole.
    public static void SaveBaseImage(Weapon weapon, BaseDTO returnDTO)
    {
        byte[] pngBytes = ImageConversion.EncodeToPNG(MakeTextureReadable(weapon.ItemDefinition.artwork.texture));

        string name = Regex.Replace(returnDTO.Name, @"[^a-zA-Z0-9\s\(\)\[\]\-]", "");
        string rootDir = Paths.GameRootPath;
        string folderPath = Path.Combine(rootDir, "Extracted Data\\Weapons\\Images\\");
        Directory.CreateDirectory(folderPath);

        string outputPath = Path.Combine(folderPath, $"{name.ToLower().Replace(" ", "_")}.png");
        File.WriteAllBytes(outputPath, pngBytes);
    }

    public static Texture2D MakeTextureReadable(Texture2D source)
    {
        RenderTexture renderTex = RenderTexture.GetTemporary(
            source.width, source.height, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear);

        Graphics.Blit(source, renderTex);
        RenderTexture previous = RenderTexture.active;
        RenderTexture.active = renderTex;

        Texture2D readableText = new(source.width, source.height);
        readableText.ReadPixels(new Rect(0, 0, renderTex.width, renderTex.height), 0, 0);
        readableText.Apply();

        RenderTexture.active = previous;
        RenderTexture.ReleaseTemporary(renderTex);
        return readableText;
    }
}
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class Link : MonoBehaviour 
{

	public void OpenItchPage()
	{
#if !UNITY_EDITOR
		openWindow("https://ammazzadrago.itch.io/");
#endif
	}

	[DllImport("__Internal")]
	private static extern void openWindow(string url);

}
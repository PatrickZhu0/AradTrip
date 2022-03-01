using System;
using System.Collections;
using System.IO;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BF7 RID: 7159
	public class TakePhotoModeFrame : ClientFrame
	{
		// Token: 0x060118B4 RID: 71860 RVA: 0x0051ABC9 File Offset: 0x00518FC9
		protected override void _bindExUI()
		{
			this.mClose = this.mBind.GetCom<Button>("Close");
			this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
		}

		// Token: 0x060118B5 RID: 71861 RVA: 0x0051ABFD File Offset: 0x00518FFD
		protected override void _unbindExUI()
		{
			this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			this.mClose = null;
		}

		// Token: 0x060118B6 RID: 71862 RVA: 0x0051AC22 File Offset: 0x00519022
		private void _onCloseButtonClick()
		{
			base.Close(false);
		}

		// Token: 0x060118B7 RID: 71863 RVA: 0x0051AC2B File Offset: 0x0051902B
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TownUI/TakePhotoModeFrame";
		}

		// Token: 0x060118B8 RID: 71864 RVA: 0x0051AC34 File Offset: 0x00519034
		public static void MobileScreenShoot(Camera camera = null, float x = 0f, float y = 0f, float width = 1f, float height = 1f)
		{
			string name = string.Format("{0:yyyy-MM-dd-HH_mm_ss_ffff}", DateTime.Now);
			if (TakePhotoModeFrame.waitToScreenShoot != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(TakePhotoModeFrame.waitToScreenShoot);
			}
			TakePhotoModeFrame.waitToScreenShoot = MonoSingleton<GameFrameWork>.instance.StartCoroutine(TakePhotoModeFrame.WaitToScreenShoot(name, camera, new Rect(0f * x, 0f * y, (float)Screen.width * width, (float)Screen.height * height)));
		}

		// Token: 0x060118B9 RID: 71865 RVA: 0x0051ACAC File Offset: 0x005190AC
		protected static IEnumerator WaitToScreenShoot(string name, Camera camera, Rect rect)
		{
			yield return new WaitForEndOfFrame();
			name += ".jpg";
			RenderTexture currentRT = RenderTexture.active;
			if (camera)
			{
				RenderTexture.active = camera.targetTexture;
				camera.Render();
			}
			Texture2D image = new Texture2D((int)rect.width, (int)rect.height);
			image.ReadPixels(rect, 0, 0);
			image.Apply();
			if (camera)
			{
				RenderTexture.active = currentRT;
			}
			byte[] bytes = image.EncodeToPNG();
			string path = Application.persistentDataPath;
			if (Application.platform == 11)
			{
				path = Application.persistentDataPath.Substring(0, Application.persistentDataPath.IndexOf("Android")) + TR.Value("zymg_game_name");
			}
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			try
			{
				File.WriteAllBytes(path + "/" + name, bytes);
				Singleton<PluginManager>.GetInstance().ScanFile(path + "/" + name);
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("haveSucceedSnapPic"), CommonTipsDesc.eShowMode.SI_UNIQUE);
			}
			catch (Exception ex)
			{
				Debug.Log(ex);
			}
			yield break;
		}

		// Token: 0x0400B683 RID: 46723
		private static bool isInitAlart;

		// Token: 0x0400B684 RID: 46724
		private Button mClose;

		// Token: 0x0400B685 RID: 46725
		private Button mScreenShoot;

		// Token: 0x0400B686 RID: 46726
		protected static Coroutine waitToScreenShoot;
	}
}

using System;
using UnityEngine;

namespace GTPush
{
	// Token: 0x02004981 RID: 18817
	public class GTPushBinding
	{
		// Token: 0x0601B05C RID: 110684 RVA: 0x008512C8 File Offset: 0x0084F6C8
		static GTPushBinding()
		{
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.getui.getuiunity.GTPushBridge"))
			{
				GTPushBinding._plugin = androidJavaClass.CallStatic<AndroidJavaObject>("getInstance", new object[0]);
			}
		}

		// Token: 0x0601B05E RID: 110686 RVA: 0x00851320 File Offset: 0x0084F720
		public static void initPush(string gameObject)
		{
			GTPushBinding._plugin.Call("initPush", new object[]
			{
				gameObject
			});
		}

		// Token: 0x0601B05F RID: 110687 RVA: 0x0085133B File Offset: 0x0084F73B
		public static void setPushMode(bool turnOn)
		{
			GTPushBinding._plugin.Call("setPushMode", new object[]
			{
				turnOn
			});
		}

		// Token: 0x0601B060 RID: 110688 RVA: 0x0085135C File Offset: 0x0084F75C
		public static string getVersion()
		{
			return GTPushBinding._plugin.Call<string>("getVersion", new object[0]);
		}

		// Token: 0x0601B061 RID: 110689 RVA: 0x00851380 File Offset: 0x0084F780
		public static string getClientId()
		{
			return GTPushBinding._plugin.Call<string>("getClientId", new object[0]);
		}

		// Token: 0x0601B062 RID: 110690 RVA: 0x008513A4 File Offset: 0x0084F7A4
		public static bool isPushTurnOn()
		{
			return GTPushBinding._plugin.Call<bool>("isPushTurnOn", new object[0]);
		}

		// Token: 0x0601B063 RID: 110691 RVA: 0x008513C8 File Offset: 0x0084F7C8
		public static void turnOnPush()
		{
			GTPushBinding._plugin.Call("turnOnPush", new object[0]);
		}

		// Token: 0x0601B064 RID: 110692 RVA: 0x008513DF File Offset: 0x0084F7DF
		public static void turnOffPush()
		{
			GTPushBinding._plugin.Call("turnOffPush", new object[0]);
		}

		// Token: 0x0601B065 RID: 110693 RVA: 0x008513F8 File Offset: 0x0084F7F8
		public static bool setTag(string tags)
		{
			return GTPushBinding._plugin.Call<int>("setTag", new object[]
			{
				tags
			}) == 0;
		}

		// Token: 0x0601B066 RID: 110694 RVA: 0x00851428 File Offset: 0x0084F828
		public static bool bindAlias(string alias)
		{
			return GTPushBinding._plugin.Call<bool>("bindAlias", new object[]
			{
				alias
			});
		}

		// Token: 0x0601B067 RID: 110695 RVA: 0x00851450 File Offset: 0x0084F850
		public static bool unBindAlias(string alias)
		{
			return GTPushBinding._plugin.Call<bool>("unBindAlias", new object[]
			{
				alias
			});
		}

		// Token: 0x0601B068 RID: 110696 RVA: 0x00851478 File Offset: 0x0084F878
		public static void setChannelId(string aChannelId)
		{
		}

		// Token: 0x0601B069 RID: 110697 RVA: 0x0085147A File Offset: 0x0084F87A
		public static void destroy()
		{
		}

		// Token: 0x0601B06A RID: 110698 RVA: 0x0085147C File Offset: 0x0084F87C
		public static void resume()
		{
			GTPushBinding._plugin.Call("turnOnPush", new object[0]);
		}

		// Token: 0x04012D8C RID: 77196
		private static AndroidJavaObject _plugin;
	}
}

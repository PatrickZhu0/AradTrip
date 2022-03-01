using System;

namespace GameClient
{
	// Token: 0x0200179C RID: 6044
	public class MallNewFrame : ClientFrame
	{
		// Token: 0x0600EE67 RID: 61031 RVA: 0x003FFEAC File Offset: 0x003FE2AC
		public static void OpenLinkFrame(string strParam)
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MallNewFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<MallNewFrame>(null, false);
			}
			try
			{
				string[] array = strParam.Split(new char[]
				{
					'|'
				});
				if (array.Length > 0)
				{
					MallNewFrameParamData mallNewFrameParamData = new MallNewFrameParamData();
					int num = array.Length;
					if (num == 1)
					{
						mallNewFrameParamData.MallNewType = (MallNewType)int.Parse(array[0]);
					}
					else if (num == 2)
					{
						mallNewFrameParamData.MallNewType = (MallNewType)int.Parse(array[0]);
						mallNewFrameParamData.Index = int.Parse(array[1]);
					}
					else if (num == 3)
					{
						mallNewFrameParamData.MallNewType = (MallNewType)int.Parse(array[0]);
						mallNewFrameParamData.Index = int.Parse(array[1]);
						mallNewFrameParamData.SecondIndex = int.Parse(array[2]);
					}
					else if (num == 4)
					{
						mallNewFrameParamData.MallNewType = (MallNewType)int.Parse(array[0]);
						mallNewFrameParamData.Index = int.Parse(array[1]);
						mallNewFrameParamData.SecondIndex = int.Parse(array[2]);
						mallNewFrameParamData.ThirdIndex = int.Parse(array[3]);
					}
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<MallNewFrame>(FrameLayer.Middle, mallNewFrameParamData, string.Empty);
				}
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("MallNewFrame OpenLinkFrame throw exception {0}", new object[]
				{
					ex.ToString()
				});
			}
		}

		// Token: 0x0600EE68 RID: 61032 RVA: 0x003FFFFC File Offset: 0x003FE3FC
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/MallNew/MallNewFrame";
		}

		// Token: 0x0600EE69 RID: 61033 RVA: 0x00400004 File Offset: 0x003FE404
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mMallNewView != null)
			{
				MallNewFrameParamData paramData = null;
				if (this.userData != null)
				{
					paramData = (MallNewFrameParamData)this.userData;
				}
				this.InitDefaultTabData(paramData);
				this.mMallNewView.InitView();
			}
		}

		// Token: 0x0600EE6A RID: 61034 RVA: 0x00400054 File Offset: 0x003FE454
		private void InitDefaultTabData(MallNewFrameParamData paramData)
		{
			MallNewFrame.DefaultMainTabIndex = 0;
			MallNewFrame.DefaultIndex = 0;
			MallNewFrame.SecondIndex = 0;
			MallNewFrame.ThirdIndex = 0;
			if (paramData == null)
			{
				return;
			}
			if (paramData.MallNewType > MallNewType.ReChargeMall || paramData.MallNewType < MallNewType.PropertyMall)
			{
				paramData.MallNewType = MallNewType.PropertyMall;
			}
			MallNewFrame.DefaultMainTabIndex = (int)paramData.MallNewType;
			MallNewFrame.DefaultIndex = paramData.Index;
			MallNewFrame.SecondIndex = paramData.SecondIndex;
			MallNewFrame.ThirdIndex = paramData.ThirdIndex;
		}

		// Token: 0x0600EE6B RID: 61035 RVA: 0x004000CB File Offset: 0x003FE4CB
		protected override void _OnCloseFrame()
		{
			DataManager<MallNewDataManager>.GetInstance().ClearData();
			MallNewFrame.CloseMallPayFrame();
			MallNewFrame.DefaultMainTabIndex = 0;
			MallNewFrame.DefaultIndex = 0;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.UpdatePetFoodNum, null, null, null, null);
		}

		// Token: 0x0600EE6C RID: 61036 RVA: 0x004000FB File Offset: 0x003FE4FB
		protected override void _bindExUI()
		{
			this.mMallNewView = this.mBind.GetCom<MallNewView>("MallNewView");
		}

		// Token: 0x0600EE6D RID: 61037 RVA: 0x00400113 File Offset: 0x003FE513
		protected override void _unbindExUI()
		{
			this.mMallNewView = null;
		}

		// Token: 0x0600EE6E RID: 61038 RVA: 0x0040011C File Offset: 0x003FE51C
		public static void OpenMallPayFrame()
		{
			MallNewFrame.CloseMallPayFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<MallPayFrame>(FrameLayer.Middle, VipTabType.PAY, string.Empty);
		}

		// Token: 0x0600EE6F RID: 61039 RVA: 0x0040013A File Offset: 0x003FE53A
		public static void CloseMallPayFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MallPayFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<MallPayFrame>(null, false);
			}
		}

		// Token: 0x040091D9 RID: 37337
		public static int DefaultMainTabIndex;

		// Token: 0x040091DA RID: 37338
		public static int DefaultIndex;

		// Token: 0x040091DB RID: 37339
		public static int SecondIndex;

		// Token: 0x040091DC RID: 37340
		public static int ThirdIndex;

		// Token: 0x040091DD RID: 37341
		private MallNewView mMallNewView;
	}
}

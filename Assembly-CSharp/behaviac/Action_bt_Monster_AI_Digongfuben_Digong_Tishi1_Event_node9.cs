using System;

namespace behaviac
{
	// Token: 0x02003271 RID: 12913
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Digongfuben_Digong_Tishi1_Event_node9 : Action
	{
		// Token: 0x06014D5F RID: 85343 RVA: 0x00646C67 File Offset: 0x00645067
		public Action_bt_Monster_AI_Digongfuben_Digong_Tishi1_Event_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "找到了宝藏钥匙！可以开启宝藏大宝箱了！";
			this.method_p1 = 5f;
			this.method_p2 = 2;
		}

		// Token: 0x06014D60 RID: 85344 RVA: 0x00646C93 File Offset: 0x00645093
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E68A RID: 59018
		private string method_p0;

		// Token: 0x0400E68B RID: 59019
		private float method_p1;

		// Token: 0x0400E68C RID: 59020
		private int method_p2;
	}
}

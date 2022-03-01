using System;

namespace behaviac
{
	// Token: 0x020031F3 RID: 12787
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_Zui_Zui_2_node16 : Action
	{
		// Token: 0x06014C72 RID: 85106 RVA: 0x0064249E File Offset: 0x0064089E
		public Action_bt_Monster_AI_Chapter9_9_5_Zui_Zui_2_node16()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570262;
		}

		// Token: 0x06014C73 RID: 85107 RVA: 0x006424BF File Offset: 0x006408BF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5CB RID: 58827
		private BE_Target method_p0;

		// Token: 0x0400E5CC RID: 58828
		private int method_p1;
	}
}

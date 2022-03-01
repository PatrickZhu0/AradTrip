using System;

namespace behaviac
{
	// Token: 0x02003193 RID: 12691
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_2_Zui_Kexilazhiyan_Shihuatai_node3 : Action
	{
		// Token: 0x06014BBC RID: 84924 RVA: 0x0063E9BB File Offset: 0x0063CDBB
		public Action_bt_Monster_AI_Chapter9_9_5_2_Zui_Kexilazhiyan_Shihuatai_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521782;
			this.method_p2 = 100;
			this.method_p3 = 61;
			this.method_p4 = 0;
		}

		// Token: 0x06014BBD RID: 84925 RVA: 0x0063E9F3 File Offset: 0x0063CDF3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E529 RID: 58665
		private BE_Target method_p0;

		// Token: 0x0400E52A RID: 58666
		private int method_p1;

		// Token: 0x0400E52B RID: 58667
		private int method_p2;

		// Token: 0x0400E52C RID: 58668
		private int method_p3;

		// Token: 0x0400E52D RID: 58669
		private int method_p4;
	}
}

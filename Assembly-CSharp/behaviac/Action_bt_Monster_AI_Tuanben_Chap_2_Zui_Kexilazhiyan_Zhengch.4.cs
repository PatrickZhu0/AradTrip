using System;

namespace behaviac
{
	// Token: 0x020037E6 RID: 14310
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Zhengchangtai_Hard_node3 : Action
	{
		// Token: 0x060157C4 RID: 88004 RVA: 0x0067C28F File Offset: 0x0067A68F
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Zhengchangtai_Hard_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521782;
			this.method_p2 = 100;
			this.method_p3 = 61;
			this.method_p4 = 0;
		}

		// Token: 0x060157C5 RID: 88005 RVA: 0x0067C2C7 File Offset: 0x0067A6C7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F191 RID: 61841
		private BE_Target method_p0;

		// Token: 0x0400F192 RID: 61842
		private int method_p1;

		// Token: 0x0400F193 RID: 61843
		private int method_p2;

		// Token: 0x0400F194 RID: 61844
		private int method_p3;

		// Token: 0x0400F195 RID: 61845
		private int method_p4;
	}
}

using System;

namespace behaviac
{
	// Token: 0x02003DA7 RID: 15783
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Wangzhiyiji_weishi_Wangzhiyiji_weishi_Move_node3 : Condition
	{
		// Token: 0x060162DF RID: 90847 RVA: 0x006B49FD File Offset: 0x006B2DFD
		public Condition_bt_Monster_AI_Wangzhiyiji_weishi_Wangzhiyiji_weishi_Move_node3()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x060162E0 RID: 90848 RVA: 0x006B4A10 File Offset: 0x006B2E10
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB2A RID: 64298
		private float opl_p0;
	}
}

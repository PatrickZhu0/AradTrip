using System;

namespace behaviac
{
	// Token: 0x020031FD RID: 12797
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node16 : Condition
	{
		// Token: 0x06014C84 RID: 85124 RVA: 0x00642CD3 File Offset: 0x006410D3
		public Condition_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Action_node16()
		{
			this.opl_p0 = 0.14f;
		}

		// Token: 0x06014C85 RID: 85125 RVA: 0x00642CE8 File Offset: 0x006410E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5D9 RID: 58841
		private float opl_p0;
	}
}

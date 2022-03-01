using System;

namespace behaviac
{
	// Token: 0x02003636 RID: 13878
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node28 : Condition
	{
		// Token: 0x0601548F RID: 87183 RVA: 0x0066B0D9 File Offset: 0x006694D9
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node28()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06015490 RID: 87184 RVA: 0x0066B0EC File Offset: 0x006694EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE49 RID: 61001
		private float opl_p0;
	}
}

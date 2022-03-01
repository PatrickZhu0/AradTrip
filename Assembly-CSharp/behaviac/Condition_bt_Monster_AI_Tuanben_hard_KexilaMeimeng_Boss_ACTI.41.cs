using System;

namespace behaviac
{
	// Token: 0x02003C44 RID: 15428
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node16 : Condition
	{
		// Token: 0x06016032 RID: 90162 RVA: 0x006A6D3D File Offset: 0x006A513D
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node16()
		{
			this.opl_p0 = 21067;
		}

		// Token: 0x06016033 RID: 90163 RVA: 0x006A6D50 File Offset: 0x006A5150
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F8AD RID: 63661
		private int opl_p0;
	}
}

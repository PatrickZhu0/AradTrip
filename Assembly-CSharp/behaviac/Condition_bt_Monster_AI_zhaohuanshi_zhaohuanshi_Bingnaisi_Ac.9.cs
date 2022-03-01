using System;

namespace behaviac
{
	// Token: 0x02003F83 RID: 16259
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Bingnaisi_Action_node16 : Condition
	{
		// Token: 0x06016672 RID: 91762 RVA: 0x006C6D5D File Offset: 0x006C515D
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Bingnaisi_Action_node16()
		{
			this.opl_p0 = 5355;
		}

		// Token: 0x06016673 RID: 91763 RVA: 0x006C6D70 File Offset: 0x006C5170
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FEC8 RID: 65224
		private int opl_p0;
	}
}

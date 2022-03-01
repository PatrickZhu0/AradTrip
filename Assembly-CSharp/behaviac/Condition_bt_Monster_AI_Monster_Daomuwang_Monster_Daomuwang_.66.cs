using System;

namespace behaviac
{
	// Token: 0x02003675 RID: 13941
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node9 : Condition
	{
		// Token: 0x0601550B RID: 87307 RVA: 0x0066D9D3 File Offset: 0x0066BDD3
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node9()
		{
			this.opl_p0 = 5425;
		}

		// Token: 0x0601550C RID: 87308 RVA: 0x0066D9E8 File Offset: 0x0066BDE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EEC2 RID: 61122
		private int opl_p0;
	}
}

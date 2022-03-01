using System;

namespace behaviac
{
	// Token: 0x02001DBD RID: 7613
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Mishushi_Action_node25 : Condition
	{
		// Token: 0x06012532 RID: 75058 RVA: 0x00559CA8 File Offset: 0x005580A8
		public Condition_bt_APC_APC_Mishushi_Action_node25()
		{
			this.opl_p0 = 9740;
		}

		// Token: 0x06012533 RID: 75059 RVA: 0x00559CBC File Offset: 0x005580BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF27 RID: 48935
		private int opl_p0;
	}
}

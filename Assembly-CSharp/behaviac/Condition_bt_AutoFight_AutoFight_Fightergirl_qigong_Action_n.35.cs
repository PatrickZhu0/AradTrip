using System;

namespace behaviac
{
	// Token: 0x02001F20 RID: 7968
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node62 : Condition
	{
		// Token: 0x060127E4 RID: 75748 RVA: 0x00568F12 File Offset: 0x00567312
		public Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node62()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060127E5 RID: 75749 RVA: 0x00568F28 File Offset: 0x00567328
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1DC RID: 49628
		private float opl_p0;
	}
}

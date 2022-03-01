using System;

namespace behaviac
{
	// Token: 0x02002002 RID: 8194
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node32 : Condition
	{
		// Token: 0x060129A0 RID: 76192 RVA: 0x00573CD2 File Offset: 0x005720D2
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node32()
		{
			this.opl_p0 = 0.28f;
		}

		// Token: 0x060129A1 RID: 76193 RVA: 0x00573CE8 File Offset: 0x005720E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C393 RID: 50067
		private float opl_p0;
	}
}

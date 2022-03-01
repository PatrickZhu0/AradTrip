using System;

namespace behaviac
{
	// Token: 0x020031DA RID: 12762
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_Kexilazhiyan_Qiweiqiutai_node0 : Condition
	{
		// Token: 0x06014C44 RID: 85060 RVA: 0x006419F8 File Offset: 0x0063FDF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Conditon_IsDayTime();
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}

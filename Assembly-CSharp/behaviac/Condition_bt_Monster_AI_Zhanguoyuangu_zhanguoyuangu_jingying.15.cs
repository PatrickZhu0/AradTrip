using System;

namespace behaviac
{
	// Token: 0x02003F5D RID: 16221
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguoyuangu_zhanguoyuangu_jingying3_node5 : Condition
	{
		// Token: 0x06016629 RID: 91689 RVA: 0x006C5918 File Offset: 0x006C3D18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int shouhufanshang = ((BTAgent)pAgent).shouhufanshang;
			int num = 0;
			bool flag = shouhufanshang == num;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}
	}
}

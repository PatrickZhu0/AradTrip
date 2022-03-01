using System;

namespace behaviac
{
	// Token: 0x02002AEC RID: 10988
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Level_Tuanben_TuanBen_Lei_node2 : Action
	{
		// Token: 0x06013EEE RID: 81646 RVA: 0x005FB93F File Offset: 0x005F9D3F
		public Action_bt_Level_Tuanben_TuanBen_Lei_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "Sound/Dungeon/boss_Tuanben_tongyong.ogg";
		}

		// Token: 0x06013EEF RID: 81647 RVA: 0x005FB959 File Offset: 0x005F9D59
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((LevelAgent)pAgent).Action_PlayBgm(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D94D RID: 55629
		private string method_p0;
	}
}

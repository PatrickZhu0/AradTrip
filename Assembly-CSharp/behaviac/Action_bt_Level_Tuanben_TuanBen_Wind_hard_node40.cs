using System;

namespace behaviac
{
	// Token: 0x02002B10 RID: 11024
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Level_Tuanben_TuanBen_Wind_hard_node40 : Action
	{
		// Token: 0x06013F32 RID: 81714 RVA: 0x005FD40B File Offset: 0x005FB80B
		public Action_bt_Level_Tuanben_TuanBen_Wind_hard_node40()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "Sound/Dungeon/boss_Tuanben_tongyong.ogg";
		}

		// Token: 0x06013F33 RID: 81715 RVA: 0x005FD425 File Offset: 0x005FB825
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((LevelAgent)pAgent).Action_PlayBgm(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D979 RID: 55673
		private string method_p0;
	}
}

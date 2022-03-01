using System;

namespace behaviac
{
	// Token: 0x02001E30 RID: 7728
	public static class bt_APC_APC_Tiantangmanbuzhe_Event
	{
		// Token: 0x0601260F RID: 75279 RVA: 0x0055EA48 File Offset: 0x0055CE48
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("APC/APC_Tiantangmanbuzhe_Event");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Action_bt_APC_APC_Tiantangmanbuzhe_Event_node1 action_bt_APC_APC_Tiantangmanbuzhe_Event_node = new Action_bt_APC_APC_Tiantangmanbuzhe_Event_node1();
			action_bt_APC_APC_Tiantangmanbuzhe_Event_node.SetClassNameString("Action");
			action_bt_APC_APC_Tiantangmanbuzhe_Event_node.SetId(1);
			sequence.AddChild(action_bt_APC_APC_Tiantangmanbuzhe_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_APC_APC_Tiantangmanbuzhe_Event_node.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}

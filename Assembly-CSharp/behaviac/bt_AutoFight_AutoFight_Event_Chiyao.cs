using System;

namespace behaviac
{
	// Token: 0x02001ECE RID: 7886
	public static class bt_AutoFight_AutoFight_Event_Chiyao
	{
		// Token: 0x06012742 RID: 75586 RVA: 0x00565FE4 File Offset: 0x005643E4
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("AutoFight/AutoFight_Event_Chiyao");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Condition_bt_AutoFight_AutoFight_Event_Chiyao_node2 condition_bt_AutoFight_AutoFight_Event_Chiyao_node = new Condition_bt_AutoFight_AutoFight_Event_Chiyao_node2();
			condition_bt_AutoFight_AutoFight_Event_Chiyao_node.SetClassNameString("Condition");
			condition_bt_AutoFight_AutoFight_Event_Chiyao_node.SetId(2);
			sequence.AddChild(condition_bt_AutoFight_AutoFight_Event_Chiyao_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_AutoFight_AutoFight_Event_Chiyao_node.HasEvents());
			Action_bt_AutoFight_AutoFight_Event_Chiyao_node1 action_bt_AutoFight_AutoFight_Event_Chiyao_node = new Action_bt_AutoFight_AutoFight_Event_Chiyao_node1();
			action_bt_AutoFight_AutoFight_Event_Chiyao_node.SetClassNameString("Action");
			action_bt_AutoFight_AutoFight_Event_Chiyao_node.SetId(1);
			sequence.AddChild(action_bt_AutoFight_AutoFight_Event_Chiyao_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_AutoFight_AutoFight_Event_Chiyao_node.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}

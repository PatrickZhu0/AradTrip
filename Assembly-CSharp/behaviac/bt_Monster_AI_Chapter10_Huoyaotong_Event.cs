using System;

namespace behaviac
{
	// Token: 0x02003116 RID: 12566
	public static class bt_Monster_AI_Chapter10_Huoyaotong_Event
	{
		// Token: 0x06014AD5 RID: 84693 RVA: 0x0063A050 File Offset: 0x00638450
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Chapter10/Huoyaotong_Event");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Condition_bt_Monster_AI_Chapter10_Huoyaotong_Event_node1 condition_bt_Monster_AI_Chapter10_Huoyaotong_Event_node = new Condition_bt_Monster_AI_Chapter10_Huoyaotong_Event_node1();
			condition_bt_Monster_AI_Chapter10_Huoyaotong_Event_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter10_Huoyaotong_Event_node.SetId(1);
			sequence.AddChild(condition_bt_Monster_AI_Chapter10_Huoyaotong_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Chapter10_Huoyaotong_Event_node.HasEvents());
			Condition_bt_Monster_AI_Chapter10_Huoyaotong_Event_node3 condition_bt_Monster_AI_Chapter10_Huoyaotong_Event_node2 = new Condition_bt_Monster_AI_Chapter10_Huoyaotong_Event_node3();
			condition_bt_Monster_AI_Chapter10_Huoyaotong_Event_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter10_Huoyaotong_Event_node2.SetId(3);
			sequence.AddChild(condition_bt_Monster_AI_Chapter10_Huoyaotong_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Chapter10_Huoyaotong_Event_node2.HasEvents());
			Action_bt_Monster_AI_Chapter10_Huoyaotong_Event_node2 action_bt_Monster_AI_Chapter10_Huoyaotong_Event_node = new Action_bt_Monster_AI_Chapter10_Huoyaotong_Event_node2();
			action_bt_Monster_AI_Chapter10_Huoyaotong_Event_node.SetClassNameString("Action");
			action_bt_Monster_AI_Chapter10_Huoyaotong_Event_node.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_Chapter10_Huoyaotong_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Chapter10_Huoyaotong_Event_node.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}

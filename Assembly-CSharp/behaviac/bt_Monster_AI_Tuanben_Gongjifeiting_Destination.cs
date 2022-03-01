using System;

namespace behaviac
{
	// Token: 0x020039CE RID: 14798
	public static class bt_Monster_AI_Tuanben_Gongjifeiting_Destination
	{
		// Token: 0x06015B6D RID: 88941 RVA: 0x0068EF04 File Offset: 0x0068D304
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Tuanben/Gongjifeiting_Destination");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(18);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(11);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_Tuanben_Gongjifeiting_Destination_node0 condition_bt_Monster_AI_Tuanben_Gongjifeiting_Destination_node = new Condition_bt_Monster_AI_Tuanben_Gongjifeiting_Destination_node0();
			condition_bt_Monster_AI_Tuanben_Gongjifeiting_Destination_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Gongjifeiting_Destination_node.SetId(0);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_Gongjifeiting_Destination_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_Gongjifeiting_Destination_node.HasEvents());
			Action_bt_Monster_AI_Tuanben_Gongjifeiting_Destination_node10 action_bt_Monster_AI_Tuanben_Gongjifeiting_Destination_node = new Action_bt_Monster_AI_Tuanben_Gongjifeiting_Destination_node10();
			action_bt_Monster_AI_Tuanben_Gongjifeiting_Destination_node.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Gongjifeiting_Destination_node.SetId(10);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Gongjifeiting_Destination_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Gongjifeiting_Destination_node.HasEvents());
			Compute_bt_Monster_AI_Tuanben_Gongjifeiting_Destination_node4 compute_bt_Monster_AI_Tuanben_Gongjifeiting_Destination_node = new Compute_bt_Monster_AI_Tuanben_Gongjifeiting_Destination_node4();
			compute_bt_Monster_AI_Tuanben_Gongjifeiting_Destination_node.SetClassNameString("Compute");
			compute_bt_Monster_AI_Tuanben_Gongjifeiting_Destination_node.SetId(4);
			sequence.AddChild(compute_bt_Monster_AI_Tuanben_Gongjifeiting_Destination_node);
			sequence.SetHasEvents(sequence.HasEvents() | compute_bt_Monster_AI_Tuanben_Gongjifeiting_Destination_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Action_bt_Monster_AI_Tuanben_Gongjifeiting_Destination_node23 action_bt_Monster_AI_Tuanben_Gongjifeiting_Destination_node2 = new Action_bt_Monster_AI_Tuanben_Gongjifeiting_Destination_node23();
			action_bt_Monster_AI_Tuanben_Gongjifeiting_Destination_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Gongjifeiting_Destination_node2.SetId(23);
			selector.AddChild(action_bt_Monster_AI_Tuanben_Gongjifeiting_Destination_node2);
			selector.SetHasEvents(selector.HasEvents() | action_bt_Monster_AI_Tuanben_Gongjifeiting_Destination_node2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}

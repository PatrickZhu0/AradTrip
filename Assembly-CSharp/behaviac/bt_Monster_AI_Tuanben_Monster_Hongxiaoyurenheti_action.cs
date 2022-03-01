using System;

namespace behaviac
{
	// Token: 0x02003AFE RID: 15102
	public static class bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action
	{
		// Token: 0x06015DB8 RID: 89528 RVA: 0x0069AB78 File Offset: 0x00698F78
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Tuanben/Monster_Hongxiaoyurenheti_action");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(1);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(5);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node0 condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node = new Condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node0();
			condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node.SetId(0);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node.HasEvents());
			Assignment_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node7 assignment_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node = new Assignment_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node7();
			assignment_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node.SetClassNameString("Assignment");
			assignment_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node.SetId(7);
			sequence.AddChild(assignment_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node);
			sequence.SetHasEvents(sequence.HasEvents() | assignment_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node.HasEvents());
			Assignment_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node8 assignment_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node2 = new Assignment_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node8();
			assignment_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node2.SetClassNameString("Assignment");
			assignment_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node2.SetId(8);
			sequence.AddChild(assignment_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node2);
			sequence.SetHasEvents(sequence.HasEvents() | assignment_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node2.HasEvents());
			Condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node6 condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node2 = new Condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node6();
			condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node2.SetId(6);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node2.HasEvents());
			Condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node11 condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node3 = new Condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node11();
			condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node3.SetId(11);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node3);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node3.HasEvents());
			Condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node12 condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node4 = new Condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node12();
			condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node4.SetId(12);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node4);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node4.HasEvents());
			Action_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node9 action_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node = new Action_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node9();
			action_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node.SetId(9);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(2);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node3 condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node5 = new Condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node3();
			condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node5.SetId(3);
			sequence2.AddChild(condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node5);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node5.HasEvents());
			Condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node4 condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node6 = new Condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node4();
			condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node6.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node6.SetId(4);
			sequence2.AddChild(condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node6);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node6.HasEvents());
			Action_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node10 action_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node2 = new Action_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node10();
			action_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node2.SetId(10);
			sequence2.AddChild(action_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}

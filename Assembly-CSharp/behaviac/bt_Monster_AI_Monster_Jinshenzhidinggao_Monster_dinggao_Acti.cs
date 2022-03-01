using System;

namespace behaviac
{
	// Token: 0x02003691 RID: 13969
	public static class bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action
	{
		// Token: 0x06015540 RID: 87360 RVA: 0x0066EDA8 File Offset: 0x0066D1A8
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Monster_Jinshenzhidinggao/Monster_dinggao_Action");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(13);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node12 condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node = new Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node12();
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node.SetId(12);
			sequence.AddChild(condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node.HasEvents());
			Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node11 action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node = new Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node11();
			action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node.SetId(11);
			sequence.AddChild(action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(1);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node2 condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node2 = new Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node2();
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node2.SetId(2);
			sequence2.AddChild(condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node2.HasEvents());
			Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node3 condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node3 = new Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node3();
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node3.SetId(3);
			sequence2.AddChild(condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node3.HasEvents());
			Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node4 condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node4 = new Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node4();
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node4.SetId(4);
			sequence2.AddChild(condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node4.HasEvents());
			Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node5 action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node2 = new Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node5();
			action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node2.SetId(5);
			sequence2.AddChild(action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(6);
			selector.AddChild(sequence3);
			Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node7 condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node5 = new Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node7();
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node5.SetId(7);
			sequence3.AddChild(condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node5);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node5.HasEvents());
			Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node8 condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node6 = new Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node8();
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node6.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node6.SetId(8);
			sequence3.AddChild(condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node6);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node6.HasEvents());
			Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node9 condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node7 = new Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node9();
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node7.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node7.SetId(9);
			sequence3.AddChild(condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node7);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node7.HasEvents());
			Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node10 action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node3 = new Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node10();
			action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node3.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node3.SetId(10);
			sequence3.AddChild(action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence3.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}

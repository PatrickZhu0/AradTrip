using System;

namespace behaviac
{
	// Token: 0x02003404 RID: 13316
	public static class bt_Monster_AI_Heisedadi_Emo_Destiation
	{
		// Token: 0x0601505A RID: 86106 RVA: 0x00655478 File Offset: 0x00653878
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Heisedadi/Emo_Destiation");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node3 condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node = new Condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node3();
			condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node.SetId(3);
			sequence.AddChild(condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node.HasEvents());
			Action_bt_Monster_AI_Heisedadi_Emo_Destiation_node4 action_bt_Monster_AI_Heisedadi_Emo_Destiation_node = new Action_bt_Monster_AI_Heisedadi_Emo_Destiation_node4();
			action_bt_Monster_AI_Heisedadi_Emo_Destiation_node.SetClassNameString("Action");
			action_bt_Monster_AI_Heisedadi_Emo_Destiation_node.SetId(4);
			sequence.AddChild(action_bt_Monster_AI_Heisedadi_Emo_Destiation_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Heisedadi_Emo_Destiation_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(2);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node5 condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node2 = new Condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node5();
			condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node2.SetId(5);
			sequence2.AddChild(condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node2.HasEvents());
			Action_bt_Monster_AI_Heisedadi_Emo_Destiation_node6 action_bt_Monster_AI_Heisedadi_Emo_Destiation_node2 = new Action_bt_Monster_AI_Heisedadi_Emo_Destiation_node6();
			action_bt_Monster_AI_Heisedadi_Emo_Destiation_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Heisedadi_Emo_Destiation_node2.SetId(6);
			sequence2.AddChild(action_bt_Monster_AI_Heisedadi_Emo_Destiation_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Heisedadi_Emo_Destiation_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(12);
			selector.AddChild(sequence3);
			Condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node10 condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node3 = new Condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node10();
			condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node3.SetId(10);
			sequence3.AddChild(condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node3.HasEvents());
			Action_bt_Monster_AI_Heisedadi_Emo_Destiation_node8 action_bt_Monster_AI_Heisedadi_Emo_Destiation_node3 = new Action_bt_Monster_AI_Heisedadi_Emo_Destiation_node8();
			action_bt_Monster_AI_Heisedadi_Emo_Destiation_node3.SetClassNameString("Action");
			action_bt_Monster_AI_Heisedadi_Emo_Destiation_node3.SetId(8);
			sequence3.AddChild(action_bt_Monster_AI_Heisedadi_Emo_Destiation_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_Heisedadi_Emo_Destiation_node3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence3.HasEvents());
			Sequence sequence4 = new Sequence();
			sequence4.SetClassNameString("Sequence");
			sequence4.SetId(9);
			selector.AddChild(sequence4);
			Condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node14 condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node4 = new Condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node14();
			condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node4.SetId(14);
			sequence4.AddChild(condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node4);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node4.HasEvents());
			Action_bt_Monster_AI_Heisedadi_Emo_Destiation_node15 action_bt_Monster_AI_Heisedadi_Emo_Destiation_node4 = new Action_bt_Monster_AI_Heisedadi_Emo_Destiation_node15();
			action_bt_Monster_AI_Heisedadi_Emo_Destiation_node4.SetClassNameString("Action");
			action_bt_Monster_AI_Heisedadi_Emo_Destiation_node4.SetId(15);
			sequence4.AddChild(action_bt_Monster_AI_Heisedadi_Emo_Destiation_node4);
			sequence4.SetHasEvents(sequence4.HasEvents() | action_bt_Monster_AI_Heisedadi_Emo_Destiation_node4.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence4.HasEvents());
			Sequence sequence5 = new Sequence();
			sequence5.SetClassNameString("Sequence");
			sequence5.SetId(13);
			selector.AddChild(sequence5);
			Condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node11 condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node5 = new Condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node11();
			condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node5.SetId(11);
			sequence5.AddChild(condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node5);
			sequence5.SetHasEvents(sequence5.HasEvents() | condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node5.HasEvents());
			Action_bt_Monster_AI_Heisedadi_Emo_Destiation_node7 action_bt_Monster_AI_Heisedadi_Emo_Destiation_node5 = new Action_bt_Monster_AI_Heisedadi_Emo_Destiation_node7();
			action_bt_Monster_AI_Heisedadi_Emo_Destiation_node5.SetClassNameString("Action");
			action_bt_Monster_AI_Heisedadi_Emo_Destiation_node5.SetId(7);
			sequence5.AddChild(action_bt_Monster_AI_Heisedadi_Emo_Destiation_node5);
			sequence5.SetHasEvents(sequence5.HasEvents() | action_bt_Monster_AI_Heisedadi_Emo_Destiation_node5.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence5.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}

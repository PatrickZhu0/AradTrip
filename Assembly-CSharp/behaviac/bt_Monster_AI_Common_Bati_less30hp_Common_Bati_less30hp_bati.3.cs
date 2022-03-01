using System;

namespace behaviac
{
	// Token: 0x0200322F RID: 12847
	public static class bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS03_Event
	{
		// Token: 0x06014CE4 RID: 85220 RVA: 0x00644C60 File Offset: 0x00643060
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Common_Bati_less30hp/Common_Bati_less30hp_bati_BOSS03_Event");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS03_Event_node1 condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS03_Event_node = new Condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS03_Event_node1();
			condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS03_Event_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS03_Event_node.SetId(1);
			sequence.AddChild(condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS03_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS03_Event_node.HasEvents());
			Condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS03_Event_node2 condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS03_Event_node2 = new Condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS03_Event_node2();
			condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS03_Event_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS03_Event_node2.SetId(2);
			sequence.AddChild(condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS03_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS03_Event_node2.HasEvents());
			Action_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS03_Event_node3 action_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS03_Event_node = new Action_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS03_Event_node3();
			action_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS03_Event_node.SetClassNameString("Action");
			action_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS03_Event_node.SetId(3);
			sequence.AddChild(action_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS03_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS03_Event_node.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}

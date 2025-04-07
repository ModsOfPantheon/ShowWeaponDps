using HarmonyLib;
using Il2Cpp;

namespace ShowWeaponDps.Hooks;

[HarmonyPatch(typeof(UIItemTooltip), nameof(UIItemTooltip.Show))]
public class UIItemTooltipHooks
{
    private static void Postfix(UIItemTooltip __instance, Item item)
    {
        var dpsText = UIItemTooltip.Instance.DPSText;

        var isWeapon = item.Template.ItemTypeId == ItemType.Weapon;
        dpsText.gameObject.active = isWeapon;

        if (!isWeapon)
        {
            return;
        }

        dpsText.text = $"({MathF.Round(item.Template.MaxDamage / item.Template.Delay, 1):F1} DPS)";
    }
}
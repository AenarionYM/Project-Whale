using UnityEngine;
using UnityEngine.UI;

public class SpellSlotController : MonoBehaviour
{
    public Image[] spellSlotImages; // UI Images for spell slots
    public Spell[] assignedSpells; // Spells assigned to each slot
    private float[] cooldownTimers; // Cooldown for each slot

    void Start()
    {
        cooldownTimers = new float[spellSlotImages.Length];
        UpdateSpellSlots();
    }

    void Update()
    {
        HandleCooldowns();
        HandleSpellInput();
    }

    // Assign spells to slots
    public void AssignSpellToSlot(int slotIndex, Spell spell)
    {
        if (slotIndex >= 0 && slotIndex < assignedSpells.Length)
        {
            assignedSpells[slotIndex] = spell;
            UpdateSpellSlots();
        }
    }

    // Update the UI slots with the correct spell icons
    private void UpdateSpellSlots()
    {
        for (int i = 0; i < spellSlotImages.Length; i++)
        {
            if (assignedSpells[i] != null)
            {
                spellSlotImages[i].sprite = assignedSpells[i].spellIcon;
                spellSlotImages[i].color = Color.white; // Ensure the icon is visible
            }
            else
            {
                spellSlotImages[i].sprite = null;
                spellSlotImages[i].color = new Color(1, 1, 1, 0); // Hide empty slots
            }
        }
    }

    // Handle cooldowns for spells
    private void HandleCooldowns()
    {
        for (int i = 0; i < cooldownTimers.Length; i++)
        {
            if (cooldownTimers[i] > 0)
            {
                cooldownTimers[i] -= Time.deltaTime;
            }
        }
    }

    // Handle spell activation when keys are pressed
    private void HandleSpellInput()
    {
        for (int i = 0; i < assignedSpells.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i) && cooldownTimers[i] <= 0)
            {
                ActivateSpell(i);
            }
        }
    }

    // Activate the spell in the specified slot
    private void ActivateSpell(int slotIndex)
    {
        if (assignedSpells[slotIndex] != null)
        {
            // Spawn the spell's effect or trigger its behavior
            if (assignedSpells[slotIndex].spellPrefab != null)
            {
                Instantiate(assignedSpells[slotIndex].spellPrefab, transform.position, Quaternion.identity);
            }

            // Start the cooldown
            cooldownTimers[slotIndex] = assignedSpells[slotIndex].cooldownTime;
            Debug.Log($"Activated Spell: {assignedSpells[slotIndex].spellName}");
        }
    }
}

# Sulfur Weapon Grabber

This plugin is built on the concept of being able to mine the weapon data inside of [Sulfur](https://store.steampowered.com/app/2124120/SULFUR/), to allow community members, the people managing the wiki and modders to gain insight into the actual weapon statistics and the game's current state. This tool was also created with the goal of checking for shadow-buff/nerfs.

## Requirements

- Sulfur
- Bepinex (6.X)

## Installation & Use

Simply unpack the **zip** file into your games `Bepinex/Plugins` folder.
When you open a save, the game will spawn a copy of every known weapon in the game, causing a small lag spike as it spawns one weapon each frame.

The weapon in Slot 0 (Primary), and Gadet 0 (Leftmost gadget) are dropped on the floor, while the **melee** is **deleted instantly**. This is due to a limitation in the ability to drop melee weapons. If you want to use this plugin, it is highly suggested, though not necessary, to create a new save.

The end result is twofold. In `Extracted Data/Weapons` you will find an `Images` folder, containing the icons of every weapon, alongside `weaponPropertyList.json`, which contains all the extractable data from the different weapon types.

## Data Structure

The data structue of the exported weapons is as follows:
Each weapon consists of a `BaseDTO`, which is split into `Throwable`, `Weapon` and `Melee` objects. These contain the specific logic for each weapon **category**.

`Core` contains the actual core of the weapons stats. **Damage**, **Magazine Size**, **Sell Price**, **Compatible Attachments** and other attributes that are required for the weapon to function.

`Modifiable` contains the modifiable stats in the game, and **can** be duplicates of the `Core` stats.

`Extra` contains some of the more hidden stats, alongside some **weapon category** specific statistics. While **Parries** is a `Core` stat, **DamageType** and **InventorySize** falls under `Extra`.

While not all of it may be the most obvious, we opted to follow the ingame logic to the best of our abilities, to maintain reliablity and make fixing issues down the line as smooth as possible.

## Known limitations

One thing that was considered for the plugin was figuring out a way of extracting the unqiue firemodes for some specific weapon types, such as the Neuraxis. However, due to the way it is programmed in the game (being it's own dedicated class), and requiring specific handling **anytime a similar weapon is developed**, we opted to not implement that due to development overhead and recurring technical debt.

## Contribution

We are happy to accept contributions, though the work on this project may stagnate at some point in the future. We designed this with the core system of **SULFUR**'s weapons and items in mind, and while unlikely to be changed, it is possible that it could break in the futue.

### Bugs

If there is a bug with the plugin, please raise an issue with the bug tag. It is likely to be worked on, but you can always fork the repository and create a pull-request to fix it.

### Features

Less likely to be worked on, but will be considered.

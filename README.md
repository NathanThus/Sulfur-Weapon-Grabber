# Sulfur Weapon Grabber

This plugin is built on the concept of being able to mine the weapon data inside of [Sulfur](https://store.steampowered.com/app/2124120/SULFUR/), to allow community members, the people managing the wiki and modders to gain insight into the actual weapon statistics and the game's current state. This tool was also created with the goal of checking for shadow-buff/nerfs.

## Requirements
Sulfur

Bepinex (6.X)

## Installation & Use
Simply unpack the **zip** file into your `Bepinex/Plugins` folder.
When you open a save, the game will spawn a copy of every known weapon in the game, causing a small lag spike as it spawns one weapon each frame.

The weapon in Slot 0 (Primary), and Gadet 0 (Leftmost gadget) are dropped on the floor, while the **melee** is **deleted instantly**. This is due to a limitation in the ability to drop melee weapons. If you want to use this plugin, it is highly suggested, though not necessary, to create a new save.

The end result is a JSON file called `weaponPropertyList.json` with all the weapon properties laid out, allowing for easy comparison between versions using a diff tool.

## Contribution
We are happy to accept contributions, though the work on this project may stagnate at some point in the future.

### Bugs
If there is a bug with the plugin, please raise an issue with the bug tag. It is likely to be worked on, but you can always fork the repository and create a pull-request to fix it.

### Features
Less likely to be worked on, but will be considered.

import {
    Menu,
    MenuButton,
    MenuList,
    MenuItem,
    MenuItemOption,
    MenuGroup,
    MenuOptionGroup,
    MenuDivider,
  } from '@chakra-ui/react'

export default function CreateNavigation() {
    return (
        <nav>
          <div class="nav-menu">
            <a href="http://localhost:5173/" class="main-logo"><span class="PROF">PROF</span><span class="IT">IT</span></a>
            <Menu>
              <MenuButton class="menu-button">Проекты</MenuButton>
              <MenuList class="menu-list">
                <MenuItem>Сначала новые</MenuItem>
                <MenuItem>Сначала старые</MenuItem>
              </MenuList>
            </Menu>
            <a href="#" class="users-url">Пользователи</a>
          </div>
        </nav>
    )
}